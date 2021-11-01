using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace OrderMaker.Converters.DTO
{
    public class PersonDto 
    {
        [JsonProperty("ФИО")]
        public string Name { get; set; }
        [JsonProperty("ДопФИО")]
        public string AdditionalName { get; set; }
        [JsonProperty("Группа", ItemConverterType = typeof(StringEnumConverter))]
        public GroupTypeDto Group { get; set; }
        [JsonProperty("Специальность")]
        public string Speciality { get; set; }
        [JsonProperty("Должности", ItemConverterType = typeof(StringEnumConverter))]
        public PostTypeDto[] Posts { get; set; }
    }
}