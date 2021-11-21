using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using OrderMaker.Models.Utils;

namespace OrderMaker.Models
{
    public class Order
    {
        // Заголовок
        
        [Display(Name = "Имя")]
        [MaxLength(200, ErrorMessage = Field.LengthExceeded)]
        [Required(ErrorMessage = Field.IsRequired)] 
        public string Name { get; set; } = default!;
        
        [Display(Name = "Номер")]
        [MaxLength(30, ErrorMessage = Field.LengthExceeded)]
        public string? Number { get; set; }
        
        [Display(Name = "Организация")]
        [MaxLength(200, ErrorMessage = Field.LengthExceeded)]
        public string? Company { get; set; }
        
        [Display(Name = "Подразделение")]
        [MaxLength(200, ErrorMessage = Field.LengthExceeded)]
        public string? Subdivision { get; set; }
        
        // Ответственные за безопасное проведение работ
        
        [Display(Name = "Ответственный руководитель работ")]
        public Person? Supervisor { get; set; }
        
        [Display(Name = "Допускающий")]
        public Person? Admitter { get; set; }
        
        [Display(Name = "Производитель работ")]
        public Person? Maker { get; set; }
        
        [Display(Name = "Наблюдающий")]
        public Person? Watcher { get; set; }
        
        [Display(Name = "Выдающий наряд")]
        public Person? Issuer { get; set; }
        
        [Display(Name = "Инструктаж получил")]
        public Person? BriefingListener { get; set; }
        
        [Display(Name = "Диспетчер")]
        public Person? Dispatcher { get; set; }

        [Display(Name = "Члены бригады")] 
        public List<Person> Members { get; set; } = new();
        
        // Содержание работ

        [Display(Name = "Поручается")] 
        public List<string> Assignments { get; set; } = new();

        [Display(Name = "Мероприятия по подготовке рабочих мест")]
        public List<(string Where, string What)> Arrangements { get; set; } = new();

        [Display(Name = "Отдельные указания")] 
        public List<string> Instructions { get; set; } = new();

        [Display(Name = "Разрешения на подготовку рабочих мест и на допуск")]
        public List<(string Who, DateTime? When)> PermissionAdmit { get; set; } = new();
        
        // Дата и время
        
        [Display(Name = "Наряд выдан")]
        [DisplayFormat(DataFormatString = Field.DataFormat)]
        public DateTime? Issue { get; set; }
        
        [Display(Name = "К работе приступить")]
        [DisplayFormat(DataFormatString = Field.DataFormat)]
        public DateTime? WorkBegin { get; set; }
        
        [Display(Name = "Работу закончить")]
        [DisplayFormat(DataFormatString = Field.DataFormat)]
        public DateTime? WorkEnd { get; set; }
    }
}