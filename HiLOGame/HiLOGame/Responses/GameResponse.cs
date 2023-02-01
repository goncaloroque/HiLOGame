using HILOGame.Services.Models;
using System.Text.Json.Serialization;

namespace HiLOGame.Responses
{
    /// <summary>
    /// Represents a game
    /// </summary>
    public class GameResponse
    {
        /// <summary>
        /// unique identifier of the game.
        /// </summary>
        [JsonPropertyName("id")]
        public string? ID { get; set; }

        /// <summary>
        ///description of the game.
        /// </summary>
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        /// <summary>
        /// minimum value allowed in the game.
        /// </summary>
        [JsonPropertyName("minValue")]
        public int MinValue { get; set; }

        /// <summary>
        /// maximum value allowed in the game.
        /// </summary>
        [JsonPropertyName("maxValue")]
        public int MaxValue { get; set; }

        /// <summary>
        /// total number of games played.
        /// </summary>
        [JsonPropertyName("totalGames")]
        public int TotalGames { get; set; }

        /// <summary>
        /// status of the game.
        /// </summary>
        [JsonPropertyName("status")]
        public string? Status { get; set; }

        /// <summary>
        /// list of players in the game.
        /// </summary>
        [JsonPropertyName("gamePlayers")]
        public IEnumerable<GamePlayer>? GamePlayers { get; set; }
    }
}
