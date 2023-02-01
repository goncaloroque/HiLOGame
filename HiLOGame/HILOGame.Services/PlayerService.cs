
using AutoMapper;
using HILOGame.Repositories.Interfaces;
using HILOGame.Repositories.Models;
using HILOGame.Services.Interfaces;
using HILOGame.Services.Models;

namespace HILOGame.Services
{
    /// <summary>
    /// Class for managing players registered in the system
    /// </summary>
    public class PlayerService : IPlayerService
    {
        private readonly IMapper _mapper;
        private readonly IPlayerRepository _playerRepository;

        public PlayerService(IMapper mapper,
            IPlayerRepository playerRepository)
        {

            _mapper = mapper;
            _playerRepository = playerRepository;
        }

        /// <summary>
        /// Adds a new player
        /// </summary>
        /// <param name="player">The player to be added</param>
        /// <returns>The player that was added</returns>
        public Player AddPlayer(Player player)
        {
            var playerModel = _mapper.Map<PlayerModel>(player);
            var addedPlayer = _playerRepository.AddPlayer(playerModel);

            return _mapper.Map<Player>(addedPlayer);
        }

        /// <summary>
        /// Gets a player by their ID
        /// </summary>
        /// <param name="playerId">The ID of the player to retrieve</param>
        /// <returns>The player with the specified ID or null if no player was found</returns>
        public Player GetPlayerByID(Guid id)
        {
            var playerModel = _playerRepository.GetPlayerByID(id);

            return _mapper.Map<Player>(playerModel);
        }

        /// <summary>
        /// Gets all players in the system
        /// </summary>
        /// <returns>An enumerable containing all players</returns>
        public IEnumerable<Player> GetPlayers()
        {
            var playerModels = _playerRepository.GetPlayers();

            return _mapper.Map<Player[]>(playerModels);
        }
    }
}
