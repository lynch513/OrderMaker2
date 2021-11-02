using System.ComponentModel.DataAnnotations;
using OrderMaker.Models.Interfaces;

namespace OrderMaker.Models
{
    public class Person : IPerson
    {
        [Display(Name = "ФИО")]
        public string Name { get; set; }
        
        [Display(Name = "Доп. ФИО")]
        public string AdditionalName { get; set; }
        
        [Display(Name = "Группа")]
        public GroupType Group { get; set; }
        
        [Display(Name = "Специальность")]
        public string Speciality { get; set; }
        
        [Display(Name = "Должности")]
        public PostType[] Posts { get; set; }
    }
}