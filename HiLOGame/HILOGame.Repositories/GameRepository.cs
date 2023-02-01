using HILOGame.Repositories.Interfaces;
using HILOGame.Repositories.Models;

namespace HILOGame.Repositories
{
    /// <summary>
    /// Repository class for managing games
    /// </summary>
    public class GameRepository : IGameRepository
    {
        HashSet<GameModel> _games = new HashSet<GameModel>();

        /// <summary>
        /// Adds a game to the internal game collection.
        /// </summary>
        /// <param name="game">The game to be added.</param>
        /// <returns>The added game with an assigned ID.</returns>
        public GameModel AddGame(GameModel game)
        {
            game.ID = Guid.NewGuid();
            _games.Add(game);

            return game;
        }

        /// <summary>
        /// Gets a game by its ID from the internal game collection.
        /// </summary>
        /// <param name="gameId">The ID of the game to be retrieved.</param>
        /// <returns>The game if found, otherwise null.</returns>
        public GameModel? GetGameByID(Guid gameId)
        {
            var game = _games.Where(game => game.ID.CompareTo(gameId) == 0).FirstOrDefault();

            return game;
        }

        /// <summary>
        /// Gets all games from the internal game collection.
        /// </summary>
        /// <returns>An enumerable collection of games.</returns>
        public IEnumerable<GameModel>? GetGames()
        {
            return _games.ToArray();
        }

        /// <summary>
        /// Adds a player to the specified game.
        /// </summary>
        /// <param name="gameId">The ID of the game the player should be added to.</param>
        /// <param name="gamePlayer">The player to be added to the game.</param>
        /// <returns>The game the player was added to, otherwise null if the game could not be found.</returns>
        public GameModel? AddPlayer(Guid gameId, GamePlayerModel gamePlayer)
        {
            var game = _games.Where(game => game.ID.CompareTo(gameId) == 0).FirstOrDefault();
            if (game != null)
            {
                game.GamePlayers.Add(gamePlayer);
            }

            return game;
        }

        /// <summary>
        /// Gets all players of the specified game.
        /// </summary>
        /// <param name="gameId">The ID of the game whose players should be retrieved.</param>
        /// <returns>An enumerable collection of game players, or null if the game could not be found.</returns>
        public IEnumerable<GamePlayerModel>? GetPlayers(Guid gameId)
        {
            var game = _games.Where(game => game.ID.CompareTo(gameId) == 0).FirstOrDefault();
            
            if (game != null)
            {
                return game.GamePlayers.ToArray();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Registers an attempt in the specified game.
        /// </summary>
        /// <param name="gameId">The ID of the game the attempt should be registered in.</param>
        /// <param name="attempt">The attempt to be registered in the game.</param>
        /// <returns>The game the attempt was registered in, otherwise null if the game could not be found.</returns>
        public GameModel? RegisterAttempt(Guid gameId, AttemptModel attempt)
        {
            var game = _games.Where(game => game.ID.CompareTo(gameId) == 0).FirstOrDefault();
            if (game != null)
            {
                game.Attempts.Add(attempt);
            }

            return game;
        }
    }
}