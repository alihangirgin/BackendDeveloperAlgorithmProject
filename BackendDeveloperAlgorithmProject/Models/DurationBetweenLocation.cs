using System.Text.Json.Serialization;

namespace BackendDeveloperAlgorithmProject.Models
{
    public class DurationBetweenLocation
    {
        [JsonPropertyName("from")]
        public string From { get; set; }
        [JsonPropertyName("to")]
        public string To { get; set; }
        [JsonPropertyName("duration_minutes")]
        public int DurationMinutes { get; set; }
    }
}
