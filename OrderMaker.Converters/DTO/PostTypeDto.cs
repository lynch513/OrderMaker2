using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace OrderMaker.Converters.DTO
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PostTypeDto
    {
        [EnumMember(Value = "ЧленБригады")]
        Member,
        [EnumMember(Value = "Наблюдающий")]
        Watcher,
        [EnumMember(Value = "ПроизводительРабот")]
        Maker,
        [EnumMember(Value = "Допускающий")]
        Admitter,
        [EnumMember(Value = "ОтветственныйРуководительРабот")]
        Supervisor,
        [EnumMember(Value = "ВыдающийНаряд")]
        Issuer,
        [EnumMember(Value = "Диспетчер")]
        Dispatcher
    }
}