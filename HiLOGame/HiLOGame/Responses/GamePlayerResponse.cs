using System.Text.Json.Serialization;

namespace HiLOGame.Responses
{
    /// <summary>
    /// Represents a player in the game
    /// </summary>
    public class GamePlayerResponse
    {
        /// <summary>
        /// player's unique identifier
        /// </summary>
        [JsonPropertyName("playerID")]
        public string? PlayerID { get; set; }

        /// <summary>
        /// player's name
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }
}