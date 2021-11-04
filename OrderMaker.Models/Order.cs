using System.ComponentModel.DataAnnotations;

namespace OrderMaker.Models
{
    public class Order
    {
        // Заголовок
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
        public Person[] Members { get; set; }
        
        // Служебное поле
        
        [Display(Name = "Имя")]
        public string Name { get; set; }
        
        
    }
}