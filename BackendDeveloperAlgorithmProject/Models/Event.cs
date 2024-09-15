using System.Text.Json.Serialization;

namespace BackendDeveloperAlgorithmProject.Models
{
    public class Event
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("start_time")]
        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan StartTime { get; set; }
        [JsonPropertyName("end_time")]
        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan EndTime { get; set; }
        [JsonPropertyName("location")]
        public string Location { get; set; }
        [JsonPropertyName("priority")]
        public int Priority { get; set; }
    }
}
