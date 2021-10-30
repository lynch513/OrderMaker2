using System.ComponentModel;

namespace OrderMaker.Models
{
    public enum PostType
    {
        [Description("Член бригады")]
        Member,
        [Description("Наблюдающий")]
        Watcher,
        [Description("Производитель работ")]
        Maker,
        [Description("Допускающий")]
        Admitter,
        [Description("Ответственный руководитель работ")]
        Supervisor,
        [Description("Выдающий наряд")]
        Issuer,
        [Description("Диспетчер")]
        Dispatcher
    }
}