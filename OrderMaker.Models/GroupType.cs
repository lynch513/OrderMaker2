using System.ComponentModel;

namespace OrderMaker.Models
{
    public enum GroupType
    {
        [Description("")]
        None,
        [Description("2 гр.")]
        Two,
        [Description("3 гр.")]
        Three,
        [Description("4 гр.")]
        Four,
        [Description("5 гр.")]
        Five
    }
}