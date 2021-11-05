using Newtonsoft.Json;

namespace OrderMaker.Converters.DTO
{
    public class PersonDto 
    {
        [JsonProperty("ФИО")]
        public string Name { get; set; }
        [JsonProperty("ДопФИО")]
        public string AdditionalName { get; set; }
        [JsonProperty("Группа")]
        public GroupTypeDto Group { get; set; }
        [JsonProperty("Специальность")]
        public string Speciality { get; set; }
        [JsonProperty("Должности")]
        public PostTypeDto[] Posts { get; set; }
    }
}