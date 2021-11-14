using OrderMaker.Extensions;

namespace OrderMaker.Models.Utils
{
    public static class PersonConverterExtentions
    {
        public static string GetNameWithGroup(this Person person)
        {
            var name = person.Name;
            var group = person.Group;
            return group == null ? name : $"{name} {group.GetDisplayNameAttribute()}";
        }

        public static string GetAdditionalNameOrName(this Person person) =>
            string.IsNullOrEmpty(person.AdditionalName) ? person.Name : person.AdditionalName;
        
        public static string GetAdditionalNameOrNameWithGroup(this Person person)
        {
            var additionalNameOrName = GetAdditionalNameOrName(person);
            var group = person.Group;
            return group == null ? additionalNameOrName : $"{additionalNameOrName} {group.GetDisplayNameAttribute()}";
        }

        public static string GetNameWithGroupAndSpeciality(this Person person)
        {
            var nameWithGroup = GetNameWithGroup(person);
            var speciality = person.Speciality;
            return string.IsNullOrEmpty(person.Speciality) ? nameWithGroup : $"{nameWithGroup} ({speciality})";
        }
        
        public static string GetSpecialityWithNameAndGroup(this Person person)
        {
            var nameWithGroup = GetNameWithGroup(person);
            var speciality = person.Speciality;
            return string.IsNullOrEmpty(person.Speciality) ? nameWithGroup : $"{speciality} {nameWithGroup}";
        }
        
        public static string GetAdditionalNameWithGroupAndSpeciality(this Person person)
        {
            var additionalNameWithGroup = GetAdditionalNameOrNameWithGroup(person);
            var speciality = person.Speciality;
            return string.IsNullOrEmpty(person.Speciality) ? 
                additionalNameWithGroup : $"{additionalNameWithGroup} ({speciality})";
        }
    }
}