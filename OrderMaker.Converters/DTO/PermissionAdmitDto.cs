using System;
using Newtonsoft.Json;

namespace OrderMaker.Converters.DTO
{
    public class PermissionAdmitDto
    {
        [JsonProperty("РазрешениеНаПодготовкуНаДопуск", Required = Required.Always)]
        public string Who { get; set; } = default!;
        [JsonProperty("Когда", Required = Required.Always)]
        public DateTime? When { get; set; }
    }
}