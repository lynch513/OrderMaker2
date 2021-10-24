using System.ComponentModel;

namespace OrderMaker.Models
{
    public enum PostType
    {
        [Description("член бригады")]
        Member,
        [Description("наблюдающий")]
        Watcher,
        [Description("производитель работ")]
        Maker,
        [Description("допускающий")]
        Admitter,
        [Description("ответственный руководитель работ")]
        Supervisor,
        [Description("выдающий наряд")]
        Issuer,
        [Description("диспетчер")]
        Dispatcher
    }
}