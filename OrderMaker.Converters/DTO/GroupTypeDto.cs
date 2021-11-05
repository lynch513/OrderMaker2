using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace OrderMaker.Converters.DTO
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GroupTypeDto
    {
        [EnumMember(Value = "")]
        None,
        [EnumMember(Value = "2гр")]
        Two,
        [EnumMember(Value = "3гр")]
        Three,
        [EnumMember(Value = "4гр")]
        Four,
        [EnumMember(Value = "5гр")]
        Five
    }
}