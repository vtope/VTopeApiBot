using System;
using Newtonsoft.Json;

// The code was taken from this resource: https://app.quicktype.io/?l=csharp
namespace VTopeApiBot.Helpers.JsonConverters
{
    internal class ParseStringConverter : JsonConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="t"></param>
        /// <param name="existingValue"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (long.TryParse(value, out var l))
            {
                return l;
            }
            
            throw new Exception("Cannot unmarshal type long");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="untypedValue"></param>
        /// <param name="serializer"></param>
        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
        }
    }
}