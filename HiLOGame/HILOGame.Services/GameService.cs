
using AutoMapper;
using HILOGame.Repositories.Interfaces;
using HILOGame.Repositories.Models;
using HILOGame.Services.Interfaces;
using HILOGame.Services.Models;
using HILOGame.Settings;

namespace HILOGame.Services
{
    /// <summary>
    /// Class for managing game play related activities.
    /// </summary>
    public class GameService : IGameService
    {
        private readonly IMapper _mapper;
        private readonly IGameRepository _gameRepository;
        private readonly IPlayerRepository _playerRepository;
        private readonly Random random = new Random();

        public GameService(IMapper mapper,
            IGameRepository gameRepository,
            IPlayerRepository playerRepository)
        {

            _mapper = mapper;
            _gameRepository = gameRepository;
            _playerRepository = playerRepository;
        }

        /// <summary>
        /// Creates a new game in the system.
        /// </summary>
        /// <param name="game">The game to be added.</param>
        /// <returns>The added game with an assigned ID.</returns>
        public Game CreateGame(Game game)
        {
            var gameModel = _mapper.Map<GameModel>(game);
            gameModel.MisteryNumber = GenerateMisteryNumber(gameModel);
            var addedGame = _gameRepository.AddGame(gameModel);

            return _mapper.Map<Game>(addedGame);
        }

        /// <summary>
        /// Gets a game by its ID.
        /// </summary>
        /// <param name="gameId">The ID of the game to be retrieved.</param>
        /// <returns>The game if found, otherwise null.</returns>
        public Game GetGameByID(Guid id)
        {
            var gameModel = _gameRepository.GetGameByID(id);

            return _mapper.Map<Game>(gameModel);
        }

        /// <summary>
        /// Gets all games.
        /// </summary>
        /// <returns>An enumerable collection of games.</returns>
        public IEnumerable<Game> GetGames()
        {
            var gameModels = _gameRepository.GetGames();

            return _mapper.Map<Game[]>(gameModels);
        }

        /// <summary>
        /// Adds a player to the specified game.
        /// </summary>
        /// <param name="gameId">The ID of the game the player should be added to.</param>
        /// <param name="gamePlayer">The player to be added to the game.</param>
        /// <returns>The game the player was added to, otherwise null if the game or the player could not be found.</returns>
        public Game? JoinGame(Guid gameId, Guid playerId)
        {
            var game = _gameRepository.GetGameByID(gameId);

            var player = _playerRepository.GetPlayerByID(playerId);

            if (game == null || player == null)
            {
                return null;
            }

            if (game.Status != Settings.GameStatus.NEW)
            {
                return null;
            }

            var resultGame = _gameRepository.AddPlayer(gameId, new GamePlayerModel()
            {
                PlayerID = playerId,
                Name = player.Name
            });            

            return _mapper.Map<Game>(resultGame);
        }

        /// <summary>
        /// Creates an attempt in the specified game.
        /// </summary>
        /// <param name="gameId">The ID of the game the attempt should be registered in.</param>
        /// <param name="playerId">The ID joined player.</param>
        /// <param name="attempt">The attempt to be registered in the game.</param>
        /// <returns>The game the attempt was registered in, otherwise null if the game or player could not be found.</returns>
        public string GameAttempt(Guid gameId, Guid playerId, int value)
        {
            var game = _gameRepository.GetGameByID(gameId);
            if (game == null)
            {
                throw new Exception("Invalid game");
            }

            var joinedPlayers = _gameRepository.GetPlayers(gameId);
            if (joinedPlayers != null && joinedPlayers.Count(player => player.PlayerID.CompareTo(playerId) == 0) == 0)
            {
                throw new Exception("Invalid player");
            }

            var evalResult = this.EvaluateAttempt(game, value);

            var result = _gameRepository.RegisterAttempt(gameId, new AttemptModel()
            {
                PlayerID = playerId,
                Value = value,
                Result=evalResult  
            });

            if (evalResult == AttemptResult.WIN) 
            {
                RestartGame(game);
            }

            return evalResult;
        }

        /// <summary>
        /// Evaluates an atempt.
        /// </summary>
        /// <param name="game">The game to validate the attempt.</param>
        /// <param name="value">The value to vaidate.</param>
        /// <returns>Resturns a string with the result of the evaluation</returns>
        private string EvaluateAttempt(GameModel game, int value)
        {
            if (game.MisteryNumber == value)
            {
                return AttemptResult.WIN;
            }

            if (game.MisteryNumber > value)
            {
                return AttemptResult.LOW;
            }
            else
            {
                return AttemptResult.HI;
            }
        }

        /// <summary>
        /// Generates a random number for a specific game, taken in considetation the range.
        /// </summary>
        /// <param name="game">The game for witch we are generatig the number</param>
        /// <returns>Returns a random interger</returns>
        private int GenerateMisteryNumber(GameModel game)
        {
            return random.Next(game.MinValue, game.MaxValue);
        }

        /// <summary>
        /// Restarts the game setting a new random number.
        /// </summary>
        /// <param name="game">The game for witch we are generatig the number</param>        
        private void RestartGame(GameModel game)
        {
            game.MisteryNumber = GenerateMisteryNumber(game);
        }
    }
}
