using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderMaker.Models
{
    public class Person
    {
        [Display(Name = "ФИО")] 
        [Required] 
        public string Name { get; set; } = default!;
        
        [Display(Name = "Доп. ФИО")]
        public string? AdditionalName { get; set; }
        
        [Display(Name = "Группа")]
        public GroupType? Group { get; set; }
        
        [Display(Name = "Специальность")]
        public string? Speciality { get; set; }

        [Display(Name = "Должности")] 
        public HashSet<PostType> Posts { get; set; } = new();
    }
}