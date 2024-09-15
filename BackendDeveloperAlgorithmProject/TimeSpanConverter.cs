using System.Text.Json.Serialization;
using System.Text.Json;

namespace BackendDeveloperAlgorithmProject
{
    public class TimeSpanConverter : JsonConverter<TimeSpan>
    {
        public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            TimeSpan timeSpan;
            var timeSpanString = reader.GetString();
            TimeSpan.TryParse(timeSpanString, out timeSpan);
            return timeSpan;
        }

        public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
