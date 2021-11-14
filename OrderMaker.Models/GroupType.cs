using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace OrderMaker.Models
{
    public enum GroupType
    {
        [Display(Name = "2 гр.")]
        Two,
        [Display(Name = "3 гр.")]
        Three,
        [Display(Name = "4 гр.")]
        Four,
        [Display(Name = "5 гр.")]
        Five
    }
}