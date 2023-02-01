using HILOGame.Repositories.Interfaces;
using HILOGame.Repositories.Models;

namespace HILOGame.Repositories
{
    /// <summary>
    /// Repository class for managing players
    /// </summary>
    public class PlayerRepository : IPlayerRepository
    {
        HashSet<PlayerModel> _players = new HashSet<PlayerModel>();

        /// <summary>
        /// Adds a new player to the repository
        /// </summary>
        /// <param name="player">The player to be added</param>
        /// <returns>The player that was added</returns>
        public PlayerModel AddPlayer(PlayerModel player)
        {
            player.ID = Guid.NewGuid();
            _players.Add(player);

            return player;
        }

        /// <summary>
        /// Gets a player from the repository by their ID
        /// </summary>
        /// <param name="playerId">The ID of the player to retrieve</param>
        /// <returns>The player with the specified ID or null if no player was found</returns>
        public PlayerModel? GetPlayerByID(Guid playerId)
        {
            var player = _players.Where(player => player.ID.CompareTo(playerId) == 0).FirstOrDefault();

            return player;
        }

        /// <summary>
        /// Gets all players in the repository
        /// </summary>
        /// <returns>An enumerable containing all players in the repository.</returns>
        public IEnumerable<PlayerModel>? GetPlayers()
        {
            return _players.ToArray();
        }
    }
}