using System;
using Newtonsoft.Json;
using System.Text;
// The code was taken from this resource: https://stackoverflow.com/questions/46032651/convert-string-property-value-to-base64-on-serialization
// TODO: The input is not a valid Base-64 string as it contains a non-base 64 character, more than two padding characters, or an illegal character among the padding characters.
namespace VTopeApiBot.Helpers.JsonConverters
{
    internal class CustomBase64Converter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            return Encoding.UTF8.GetString((Convert.FromBase64String((string) reader.Value)));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
           writer.WriteValue(Convert.ToBase64String(Encoding.UTF8.GetBytes((string) value)));
        }
    }
}