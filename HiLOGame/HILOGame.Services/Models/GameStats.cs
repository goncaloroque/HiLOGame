namespace HILOGame.Services.Models
{
    /// <summary>
    /// The `GameStats` class represents stats of a specific game
    /// </summary>
    public class GameStats
    {
        /// <summary>
        /// The unique identifier of the game.
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// Description of the game.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Total games played (restarts).
        /// </summary>
        public int TotalGames { get; set; }

        /// <summary>
        /// Collection of player specific stats.
        /// </summary>
        public HashSet<GameStatsPlayer> GameStatsPlayers { get; set; }

        public GameStats()
        {
            GameStatsPlayers = new HashSet<GameStatsPlayer>();
        }
    }
}