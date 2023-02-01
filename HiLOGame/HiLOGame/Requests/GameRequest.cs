using System.ComponentModel.DataAnnotations;

namespace HiLOGame.Responses
{
    /// <summary>
    /// This request used by the CreateGame function of GameController
    /// </summary>
    public class GameRequest
    {

        /// <summary>
        /// Description of the game
        /// </summary>
        [Required]
        public string? Description { get; set; }

        /// <summary>
        /// Lower value to generate radom numbers
        /// </summary>
        [Required]
        public int MinValue { get; set; }

        /// <summary>
        /// Biggest value to generate radom numbers
        /// </summary>
        [Required]
        public int MaxValue { get; set; }
    }
}
