using System.Text.Json.Serialization;

namespace HiLOGame.Responses
{
    /// <summary>
    /// Represents the response of a game's stats.
    /// </summary>
    public class GameStatsResponse
    {
        /// <summary>
        /// Gets or sets the unique identifier of the game.
        /// </summary>
        [JsonPropertyName("id")]
        public string? ID { get; set; }

        /// <summary>
        /// Gets or sets the description of the game.
        /// </summary>
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the total number of games played.
        /// </summary>
        [JsonPropertyName("totalGames")]
        public int TotalGames { get; set; }

        /// <summary>
        /// Gets or sets the statistics of players in the game.
        /// </summary>
        [JsonPropertyName("gameStatsPlayers")]
        public HashSet<GameStatsPlayerResponse> GameStatsPlayers { get; set; }

        public GameStatsResponse()
        {
            GameStatsPlayers = new HashSet<GameStatsPlayerResponse>();
        }
    }
}
