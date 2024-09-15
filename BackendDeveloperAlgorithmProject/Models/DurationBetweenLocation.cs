using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
