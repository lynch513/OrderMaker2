using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using OrderMaker.Models.Attributes;
using OrderMaker.Models.Utils;

namespace OrderMaker.Models
{
    public class Person
    {
        [Display(Name = "ФИО")]
        [MaxLength(100, ErrorMessage = Field.LengthExceeded)]
        [Required(ErrorMessage = Field.IsRequired)]
        public string Name { get; set; } = default!;

        [Display(Name = "Доп. ФИО")]
        [MaxLength(100, ErrorMessage = Field.LengthExceeded)]
        public string? AdditionalName { get; set; }

        [Display(Name = "Группа")] public GroupType? Group { get; set; }

        [Display(Name = "Специальность")]
        [MaxLength(100, ErrorMessage = Field.LengthExceeded)]
        public string? Speciality { get; set; }

        [Display(Name = "Должности")]
        [Posts] 
        public HashSet<PostType> Posts { get; set; } = new();
    }
}