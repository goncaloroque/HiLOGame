namespace HILOGame.Repositories.Models
{
    /// <summary>
    /// The `PlayerModel` represents a player registered in the game
    /// </summary>
    public class PlayerModel
    {
        /// <summary>
        /// The unique identifier of the player.
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// Players' name
        /// </summary>
        public string? Name { get; set; }
    }
}