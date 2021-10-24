using System;
using System.ComponentModel;

namespace OrderMaker.Models
{
    public class Person
    {
        [Description("ФИО")]
        public string Name { get; set; }
        
        [Description("доп. ФИО")]
        public string AdditionalName { get; set; }
        
        [Description("специальность")]
        public string Speciality { get; set; }
        
        [Description("должности")]
        public PostType[] Posts { get; set; }
        
        [Description("группа")]
        public GroupType Group { get; set; }
    }
}