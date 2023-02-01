namespace HILOGame.Services.Models
{
    /// <summary>
    /// The `Player` represents a player registered in the game
    /// </summary>
    public class Player
    {
        /// <summary>
        /// The unique identifier of the player.
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// Players' name
        /// </summary>
        public string Name { get; set; }
    }
}