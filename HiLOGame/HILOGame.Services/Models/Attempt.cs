namespace HILOGame.Services.Models
{
    /// <summary>
    /// Represents an attempt made by a player in a game.
    /// </summary>
    public class Attempt
    {
        /// <summary>
        /// The unique identifier of the player who made the attempt.
        /// </summary>
        public Guid PlayerID { get; set; }

        /// <summary>
        /// The value of the attempt.
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// The result of the attempt.
        /// </summary>
        public string? Result { get; set; }
    }
}