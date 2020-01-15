using System;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace WebApplication1.Extends
{
    public class JsonDateTimeConvert : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var paramString = reader.GetString();

            var localDateTime = Convert.ToDateTime(paramString);

            return localDateTime;
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("yyyy-MM-dd HH:mm:ss"));
        }
    }

}
