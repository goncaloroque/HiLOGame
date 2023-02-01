using System.ComponentModel.DataAnnotations;

namespace HiLOGame.Requests
{
    /// <summary>
    /// This request used by the JoinGame function of GameController
    /// </summary>
    public class JoinGameRequest
    {
        /// <summary>
        /// ID of the game to join
        /// </summary>
        [Required]
        public string? GameID { get; set; }

        /// <summary>
        /// Id of the player joing to the game
        /// </summary>
        [Required]
        public string? PlayerID { get; set; }
    }
}
