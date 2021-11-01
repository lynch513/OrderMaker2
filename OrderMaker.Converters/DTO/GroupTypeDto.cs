using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace OrderMaker.Converters.DTO
{
    public enum GroupTypeDto
    {
        [JsonProperty("")]
        [JsonConverter(typeof(StringEnumConverter))]
        None,
        [JsonProperty("2гр")]
        [JsonConverter(typeof(StringEnumConverter))]
        Two,
        [JsonProperty("3гр")]
        [JsonConverter(typeof(StringEnumConverter))]
        Three,
        [JsonProperty("4гр")]
        [JsonConverter(typeof(StringEnumConverter))]
        Four,
        [JsonProperty("5гр")]
        [JsonConverter(typeof(StringEnumConverter))]
        Five
    }
}