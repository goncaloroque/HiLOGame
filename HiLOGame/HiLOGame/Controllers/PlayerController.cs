using AutoMapper;
using HiLOGame.Requests;
using HiLOGame.Responses;
using HILOGame.Services.Interfaces;
using HILOGame.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace HiLOGame.Controllers
{
    /// <summary>
    /// The PlayersController class contains endpoints for managing players.
    /// </summary>
    [ApiController]
    [Route("[controller]/[action]")]
    public class PlayersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPlayerService _playerService;

        /// <summary>
        /// Creates a new instance of the PlayersController class.
        /// </summary>
        /// <param name="mapper">The AutoMapper instance to use for mapping between domain and DTO objects.</param>
        /// <param name="playerService">The player service to use for retrieving player information.</param>
        public PlayersController(IMapper mapper, IPlayerService playerService)
        {
            _mapper = mapper;
            _playerService = playerService;
        }

        /// <summary>
        /// Gets a player by ID.
        /// </summary>
        /// <param name="id">The ID of the player to retrieve.</param>
        /// <returns>The requested player, or a 404 Not Found result if the player was not found.</returns>
        [HttpGet("{id}")]
        public ActionResult<PlayerResponse> GetPlayerById(string id)
        {
            var player = _playerService.GetPlayerByID(Guid.Parse(id));

            if (player == null)
                return NotFound();

            return _mapper.Map<PlayerResponse>(player);
        }

        /// <summary>
        /// Gets a list of all players.
        /// </summary>
        /// <returns>A list of all players.</returns>
        [HttpGet()]
        public ActionResult<IEnumerable<PlayerResponse>> GetPlayers()
        {
            var players = _playerService.GetPlayers();

            return _mapper.Map<PlayerResponse[]>(players);
        }

        /// <summary>
        /// Adds a new player.
        /// </summary>
        /// <param name="request">The request containing information about the player to add.</param>
        /// <returns>The added player.</returns>
        [HttpPost]
        public ActionResult<PlayerResponse> PostPlayer(PlayerRequest request)
        {
            var player = _mapper.Map<Player>(request);
            var result = _playerService.AddPlayer(player);

            return _mapper.Map<PlayerResponse>(result);
        }

    }
}
