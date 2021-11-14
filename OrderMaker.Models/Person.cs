using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.PortableExecutable;

namespace OrderMaker.Models
{
    public class Person
    {
        private const string FieldLengthExceeded = "Превышена допустимая длина поля \"{0}\"";
        private const string FieldIsRequired = "Поле \"{0}\" является обязательным";
        
        [Display(Name = "ФИО")] 
        [MaxLength(100, ErrorMessage = FieldLengthExceeded)]
        [Required(ErrorMessage = FieldIsRequired)] 
        public string Name { get; set; } = default!;
        
        [Display(Name = "Доп. ФИО")]
        [MaxLength(100, ErrorMessage = FieldLengthExceeded)]
        public string? AdditionalName { get; set; }
        
        [Display(Name = "Группа")]
        public GroupType? Group { get; set; }
        
        [Display(Name = "Специальность")]
        [MaxLength(100, ErrorMessage = FieldLengthExceeded)]
        public string? Speciality { get; set; }

        [Display(Name = "Должности")] 
        public HashSet<PostType> Posts { get; set; } = new();
    }
}