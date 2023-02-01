using System.Text.Json.Serialization;

namespace HiLOGame.Responses
{
    /// <summary>
    /// Represents the response of a player's stats in the game.
    /// </summary>
    public class GameStatsPlayerResponse
    {
        /// <summary>
        /// Gets or sets the player's unique identifier.
        /// </summary>
        [JsonPropertyName("playerID")]
        public string? PlayerID { get; set; }

        /// <summary>
        /// Gets or sets the player's name.
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the number of wins the player has.
        /// </summary>
        [JsonPropertyName("wins")]
        public int Wins { get; set; }
    }
}
