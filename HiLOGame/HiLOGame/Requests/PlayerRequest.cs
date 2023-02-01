using System.ComponentModel.DataAnnotations;

namespace HiLOGame.Requests
{
    /// <summary>
    /// This request used by the PostPlayer function of PlayersController
    /// </summary>
    public class PlayerRequest
    {
        /// <summary>
        /// Name of the player
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}
