using System.ComponentModel;
using OrderMaker.Models.Interfaces;

namespace OrderMaker.Models
{
    public class Person : IPerson
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