namespace HILOGame.Services.Models
{
    /// <summary>
    /// The `GamePlayerModel` class represents a player joined to a game
    /// </summary>
    public class GamePlayer
    {
        /// <summary>
        /// The unique identifier of the player.
        /// </summary>
        public Guid PlayerID { get; set; }

        /// <summary>
        /// Name of the player
        /// </summary>
        public string? Name { get; set; }
    }
}