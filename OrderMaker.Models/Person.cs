using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderMaker.Models
{
    public class Person
    {
        [Description("ФИО")]
        public string Name { get; set; }
        
        [Description("Доп. ФИО")]
        public string AdditionalName { get; set; }
        
        [Description("Группа")]
        public GroupType Group { get; set; }
        
        [Description("Специальность")]
        public string Speciality { get; set; }
        
        [Description("Должности")]
        public PostType[] Posts { get; set; }
    }
}