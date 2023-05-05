using System.Text.Json;
using System.Text.Json.Serialization;

#pragma warning disable CS8604 // Possible null reference argument.

namespace EC.Api.Calculator.Presentation.WebApi.Configuration.OutputFormatters
{
    public class DateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.Parse(reader.GetString());
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ"));
        }
    }
}

#pragma warning restore CS8604 // Possible null reference argument.
