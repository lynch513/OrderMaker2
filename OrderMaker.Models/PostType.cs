using System.ComponentModel.DataAnnotations;

namespace OrderMaker.Models
{
    public enum PostType
    {
        [Display(Name = "Член бригады")]
        Member,
        [Display(Name = "Наблюдающий")]
        Watcher,
        [Display(Name = "Производитель работ")]
        Maker,
        [Display(Name = "Допускающий")]
        Admitter,
        [Display(Name = "Ответственный руководитель работ")]
        Supervisor,
        [Display(Name = "Выдающий наряд")]
        Issuer,
        [Display(Name = "Диспетчер")]
        Dispatcher
    }
}