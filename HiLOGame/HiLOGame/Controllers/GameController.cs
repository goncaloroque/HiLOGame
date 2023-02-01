using AutoMapper;
using HiLOGame.Requests;
using HiLOGame.Responses;
using HILOGame.Services.Interfaces;
using HILOGame.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace HiLOGame.Controllers
{
    /// <summary>
    /// This is the GameController class that handles all the game related operations.
    /// </summary>
    [ApiController]
    [Route("[controller]/[action]")]
    public class GameController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IGameService _gameService;
        private readonly IStatisticService _statisticService;

        /// <summary>
        /// This constructor initializes the GameController class with the required dependencies.
        /// </summary>
        /// <param name="mapper">An instance of the IMapper interface for mapping between entities and DTOs.</param>
        /// <param name="gameService">An instance of the IGameService interface for accessing game related operations.</param>
        /// <param name="statisticService">An instance of the IStatisticService interface for accessing statistics related operations.</param>
        public GameController(IMapper mapper,
            IGameService gameService,
            IStatisticService statisticService)
        {
            _mapper = mapper;
            _gameService = gameService;
            _statisticService = statisticService;
        }

        /// <summary>
        /// This action method retrieves the game with the specified id.
        /// </summary>
        /// <param name="id">The id of the game to retrieve.</param>
        /// <returns>Returns the game with the specified id, or a 404 Not Found error if the game does not exist.</returns>
        [HttpGet("{id}")]
        public ActionResult<GameResponse> GetGameById(string id)
        {
            var game = _gameService.GetGameByID(Guid.Parse(id));

            if (game == null)
                return NotFound();

            return _mapper.Map<GameResponse>(game);
        }

        /// <summary>
        /// This action method retrieves all the games.
        /// </summary>
        /// <returns>Returns a list of all the games.</returns>
        [HttpGet()]
        public ActionResult<IEnumerable<GameResponse>> GetGames()
        {
            var games = _gameService.GetGames();

            return _mapper.Map<GameResponse[]>(games);
        }

        /// <summary>
        /// This action method creates a new game.
        /// </summary>
        /// <param name="request">The request object containing the details for creating a new game.</param>
        /// <returns>Returns the created game.</returns>
        [HttpPost]
        public ActionResult<GameResponse> CreateGame(GameRequest request)
        {
            var game = _mapper.Map<Game>(request);
            var result = _gameService.CreateGame(game);

            return _mapper.Map<GameResponse>(result);
        }

        /// <summary>
        /// Join a game.
        /// </summary>
        /// <param name="request">JoinGameRequest object containing GameID and PlayerID</param>
        /// <returns>GameResponse object containing information about the game joined</returns>
        [HttpPost]
        public ActionResult<GameResponse> JoinGame(JoinGameRequest request)
        {
            var result = _gameService.JoinGame(Guid.Parse(request.GameID), Guid.Parse(request.PlayerID));

            if (result == null)
                return NotFound();

            return _mapper.Map<GameResponse>(result);
        }

        /// <summary>
        /// Make an attempt in a game.
        /// </summary>
        /// <param name="request">AttemptRequest object containing GameID, PlayerID and Number</param>
        /// <returns>AttemptResponse object containing the result of the attempt</returns>
        [HttpPost]
        public ActionResult<AttemptResponse> GameAttempt(AttemptRequest request)
        {
            var result = _gameService.GameAttempt(Guid.Parse(request.GameID), Guid.Parse(request.PlayerID), request.Number);

            return new AttemptResponse() { Result = result };
        }

        /// <summary>
        /// Get the statistics of a game.
        /// </summary>
        /// <param name="id">The ID of the game</param>
        /// <returns>GameStatsResponse object containing the statistics of the game</returns>
        [HttpGet("{id}")]
        public ActionResult<GameStatsResponse> GetGameStatisticsById(string id)
        {
            var gameStatictics = _statisticService.GetGameStats(Guid.Parse(id));

            if (gameStatictics == null)
                return NotFound();

            return _mapper.Map<GameStatsResponse>(gameStatictics);
        }

    }
}