using System.Text.Json.Serialization;

namespace HiLOGame.Responses
{
    /// <summary>
    /// Represents the response of a player.
    /// </summary>
    public class PlayerResponse
    {
        /// <summary>
        /// Gets or sets the unique identifier of the player.
        /// </summary>
        [JsonPropertyName("id")]
        public string? ID { get; set; }

        /// <summary>
        /// Gets or sets the name of the player.
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }
}