using System;
using Newtonsoft.Json;

namespace OrderMaker.Converters.DTO
{
    public class OrderDto
    {
        // Заголовок
        [JsonProperty("Имя", Required = Required.Always)]
        public string Name { get; set; } = default!;
        
        [JsonProperty("Номер")]
        public string? Number { get; set; }
        
        [JsonProperty("Организация")]
        public string? Company { get; set; }
        
        [JsonProperty("Подразделение")]
        public string? Subdivision { get; set; }
        
        // Ответственные за безопасное проведение работ
        
        [JsonProperty("ОтветственныйРуководительРабот")]
        public PersonDto? Supervisor { get; set; }
        
        [JsonProperty("Допускающий")]
        public PersonDto? Admitter { get; set; }
        
        [JsonProperty("ПроизводительРабот")]
        public PersonDto? Maker { get; set; }
        
        [JsonProperty("Наблюдающий")]
        public PersonDto? Watcher { get; set; }
        
        [JsonProperty("ВыдающийНаряд")]
        public PersonDto? Issuer { get; set; }
        
        [JsonProperty("ИнструктажПолучил")]
        public PersonDto? BriefingListener { get; set; }
        
        [JsonProperty("Диспетчер")]
        public PersonDto? Dispatcher { get; set; }
        
        [JsonProperty("ЧленыБригады")]
        public PersonDto[]? Members { get; set; }
        
        // Содержание работ
        
        [JsonProperty("Поручается")]
        public string[]? Assignments { get; set; }
    
        [JsonProperty("МероприятияПоПодготовкеРабочихМест")]
        public (string? Where, string? What)[]? Arrangements { get; set; }
        
        [JsonProperty("ОтдельныеУказания")]
        public string[]? Instructions { get; set; }
        
        [JsonProperty("РазрешенияНаПодготовкуРабочихМестИНаДопуск")]
        public (string? Who, DateTime? When)[]? PermissionAdmit { get; set; }
        
        // Дата и время
        
        [JsonProperty("НарядВыдан")]
        public DateTime? Issue { get; set; }
        
        [JsonProperty("КРаботеПриступить")]
        public DateTime? WorkBegin { get; set; }
        
        [JsonProperty("РаботуЗакончить")]
        public DateTime? WorkEnd { get; set; }
    }
}