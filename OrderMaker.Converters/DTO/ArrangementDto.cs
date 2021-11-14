using Newtonsoft.Json;

namespace OrderMaker.Converters.DTO
{
    public class ArrangementDto
    {
        [JsonProperty("НаименованияЭлектроустановок", Required = Required.Always)]
        public string Where { get; set; } = default!;

        [JsonProperty("ЧтоДолжноБытьОтключено", Required = Required.Always)]
        public string What { get; set; } = default!;
    }
}