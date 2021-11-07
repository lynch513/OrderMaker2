using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderMaker.Models
{
    public class Order
    {
        // Заголовок
        [Display(Name = "Имя")]
        public string Name { get; set; }
        
        [Display(Name = "Номер")]
        public string Number { get; set; }
        
        [Display(Name = "Организация")]
        public string Company { get; set; }
        
        [Display(Name = "Подразделение")]
        public string Subdivision { get; set; }
        
        // Ответственные за безопасное проведение работ
        
        [Display(Name = "Ответственный руководитель работ")]
        public Person Supervisor { get; set; }
        
        [Display(Name = "Допускающий")]
        public Person Admitter { get; set; }
        
        [Display(Name = "Производитель работ")]
        public Person Maker { get; set; }
        
        [Display(Name = "Наблюдающий")]
        public Person Watcher { get; set; }
        
        [Display(Name = "Выдающий наряд")]
        public Person Issuer { get; set; }
        
        [Display(Name = "Инструктаж получил")]
        public Person BriefingListener { get; set; }
        
        [Display(Name = "Диспетчер")]
        public Person Dispatcher { get; set; }
        
        [Display(Name = "Члены бригады")]
        public List<Person> Members { get; set; }
        
        // Содержание работ
        
        [Display(Name = "Поручается")]
        public List<string> Assignments { get; set; }
    
        [Display(Name = "Мероприятия по подготовке рабочих мест")]
        public List<(string Where, string What)> Arrangements { get; set; }
        
        [Display(Name = "Отдельные указания")]
        public List<string> Instructions { get; set; }
        
        [Display(Name = "Разрешения на подготовку рабочих мест и на допуск")]
        public List<(string Who, DateTime When)> PermissionAdmit { get; set; }
        
        // Дата и время
        
        [Display(Name = "Наряд выдан")]
        public DateTime Issue { get; set; }
        
        [Display(Name = "К работе приступить")]
        public DateTime WorkBegin { get; set; }
        
        [Display(Name = "Работу закончить")]
        public DateTime WorkEnd { get; set; }
    }
}