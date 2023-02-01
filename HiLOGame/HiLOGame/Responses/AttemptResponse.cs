using System.Text.Json.Serialization;

namespace HiLOGame.Responses
{
    /// <summary>
    /// Represents the response of an attempt in the game.
    /// </summary>
    public class AttemptResponse
    {
        /// <summary>
        /// Gets or sets the result of the attempt.
        /// </summary>
        [JsonPropertyName("result")]
        public string Result { get; set; }
    }
}