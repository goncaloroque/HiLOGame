using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace HILOGame.Settings
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GameStatus
    {
        NEW = 0,
        STARTED = 1,
        ENDED = 2,
    }
}