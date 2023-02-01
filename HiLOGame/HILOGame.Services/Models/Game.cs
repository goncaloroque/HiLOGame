using HILOGame.Settings;

namespace HILOGame.Services.Models
{
    /// <summary>
    /// The `Game` class represents a single game instance in the `HILOGame` application.
    /// </summary>
    public class Game
    {
        /// <summary>
        /// The unique identifier of the game.
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// Description of the game
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Lower value to generate radom numbers
        /// </summary>
        public int MinValue { get; set; }

        /// <summary>
        /// Biggest value to generate radom numbers
        /// </summary>
        public int MaxValue { get; set; }

        /// <summary>
        /// Mystery number to be gessed by the players.
        /// </summary>
        public int MisteryNumber { get; set; }

        /// <summary>
        /// Total games played (restarts)
        /// </summary>
        public int TotalGames { get; set; }

        /// <summary>
        /// Status of the game.
        /// 0 - New (new game without attempts)
        /// 1 - Started (Game with attempts)
        /// 2 - Ended
        /// </summary>
        public GameStatus Status { get; set; }

        /// <summary>
        /// Colletion of players that joined the game
        /// </summary>
        public HashSet<GamePlayer> GamePlayers { get; set; }

        /// <summary>
        /// Collection of attempts made by the players
        /// </summary>
        public HashSet<Attempt> Attempts { get; set; }

        public Game()
        {
            GamePlayers = new HashSet<GamePlayer>();
            Attempts = new HashSet<Attempt>();
        }
    }
}