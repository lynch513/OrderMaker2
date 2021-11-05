using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using OrderMaker.Models;

namespace OrderMaker.Converters.DTO
{
    public class OrderDto
    {
        // Заголовок
        [JsonProperty("Номер")]
        public string Number { get; set; }
        
        [JsonProperty("Организация")]
        public string Company { get; set; }
        
        [JsonProperty("Подразделение")]
        public string Subdivision { get; set; }
        
        // Ответственные за безопасное проведение работ
        
        [JsonProperty("ОтветственныйРуководительРабот")]
        public Person Supervisor { get; set; }
        
        [JsonProperty("Допускающий")]
        public Person Admitter { get; set; }
        
        [JsonProperty("ПроизводительРабот")]
        public Person Maker { get; set; }
        
        [JsonProperty("Наблюдающий")]
        public Person Watcher { get; set; }
        
        [JsonProperty("ВыдающийНаряд")]
        public Person Issuer { get; set; }
        
        [JsonProperty("ИнструктажПолучил")]
        public Person BriefingListener { get; set; }
        
        [JsonProperty("Диспетчер")]
        public Person Dispatcher { get; set; }
        
        [JsonProperty("ЧленыБригады")]
        public Person[] Members { get; set; }
        
        // Служебные поля
        
        [JsonProperty("Имя")]
        public string Name { get; set; }
        
        [JsonProperty("Создан")]
        public DateTime Created { get; set; }
        
        [JsonProperty("Обновлен")]
        public DateTime Updated { get; set; }
        
        // Содержание работ
        
        [JsonProperty("Поручается")]
        public string[] Assignments { get; set; }
    
        [JsonProperty("МероприятияПоПодготовкеРабочихМест")]
        public (string Where, string What)[] Arrangements { get; set; }
        
        [JsonProperty("ОтдельныеУказания")]
        public string[] Instructions { get; set; }
        
        [JsonProperty("РазрешенияНаПодготовкуРабочихМестИНаДопуск")]
        public (string Who, DateTime When)[] PermissionAdmit { get; set; }
        
        // Дата и время
        
        [JsonProperty("НарядВыдан")]
        public DateTime Issue { get; set; }
        
        [JsonProperty("КРаботеПриступить")]
        public DateTime WorkBegin { get; set; }
        
        [JsonProperty("РаботуЗакончить")]
        public DateTime WorkEnd { get; set; }
    }
}