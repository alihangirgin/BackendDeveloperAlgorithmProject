using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BackendDeveloperAlgorithmProject.Models
{
    public class Event
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("start_time")]
        public string StartTime { get; set; }
        [JsonPropertyName("end_time")]
        public string EndTime { get; set; }
        [JsonPropertyName("location")]
        public string Location { get; set; }
        [JsonPropertyName("priority")]
        public int Priority { get; set; }
    }
}
