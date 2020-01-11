using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// The code was taken from this resource: https://gist.github.com/marcbarry/2e7a64fed2ae539cf415
namespace VTopeApiBot.Helpers.JsonConverters
{
    // ReSharper disable once InconsistentNaming
    internal class IPAddressConverter : JsonConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public override bool CanConvert(Type objectType)
        {
            if (objectType == typeof(IPAddress)) return true;
            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (objectType == typeof(List<IPAddress>)) return true;

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="objectType"></param>
        /// <param name="existingValue"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            // convert an ipaddress represented as a string into an IPAddress object and return it to the caller
            if (objectType == typeof(IPAddress))
            {
                return IPAddress.Parse(JToken.Load(reader).ToString());
            }

            // convert a json array of ipaddresses represented as strings into a List<IPAddress> object and return it to the caller
            if (objectType == typeof(List<IPAddress>))
            {
                return JToken.Load(reader).Select(address => IPAddress.Parse((string) address)).ToList();
            }

            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="serializer"></param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // convert an IPAddress object to a string representation of itself and write it to the serialiser
            if (value.GetType() == typeof(IPAddress))
            {
                JToken.FromObject(value.ToString()).WriteTo(writer);
                return;
            }

            // convert a List<IPAddress> object to an array of strings of ipaddresses and write it to the serialiser
            // ReSharper disable once InvertIf
            if (value.GetType() == typeof(List<IPAddress>))
            {
                JToken.FromObject((from n in (List<IPAddress>) value select n.ToString()).ToList()).WriteTo(writer);
                return;
            }

            throw new NotImplementedException();

        }
    }
}