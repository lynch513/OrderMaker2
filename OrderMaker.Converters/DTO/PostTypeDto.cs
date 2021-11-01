using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace OrderMaker.Converters.DTO
{
    public enum PostTypeDto
    {
        [JsonProperty("ЧленБригады")]
        Member,
        [JsonProperty("Наблюдающий")]
        Watcher,
        [JsonProperty("ПроизводительРабот")]
        Maker,
        [JsonProperty("Допускающий")]
        Admitter,
        [JsonProperty("ОтветственныйРуководительРабот")]
        Supervisor,
        [JsonProperty("ВыдающийНаряд")]
        Issuer,
        [JsonProperty("Диспетчер")]
        Dispatcher
    }
}