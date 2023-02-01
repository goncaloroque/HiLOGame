namespace HILOGame.Services.Models
{
    /// <summary>
    /// The `GameStatsPlayer` class represents stats of a specific player in a game.
    /// </summary>
    public class GameStatsPlayer
    {
        /// <summary>
        /// The unique identifier of the player.
        /// </summary>
        public Guid PlayerID { get; set; }

        /// <summary>
        /// Player's name
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Player's wins
        /// </summary>
        public int Wins { get; set; }
    }
}