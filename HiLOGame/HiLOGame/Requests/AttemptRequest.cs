using System.ComponentModel.DataAnnotations;

namespace HiLOGame.Requests
{
    /// <summary>
    /// This request used by the GameAttempt function of GameController
    /// </summary>
    public class AttemptRequest
    {
        /// <summary>
        /// ID of the game
        /// </summary>
        [Required]
        public string GameID { get; set; }

        /// <summary>
        /// ID of the player
        /// </summary>
        [Required]
        public string PlayerID { get; set; }

        /// <summary>
        /// Number  attempted
        /// </summary>
        [Required]
        public int Number { get; set; }
    }
}
