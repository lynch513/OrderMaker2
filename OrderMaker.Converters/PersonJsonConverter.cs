using System;
using Newtonsoft.Json;
using OrderMaker.Models;

namespace OrderMaker.Converters
{
    public class PersonJsonConverter
    {
        private readonly JsonSerializerSettings _settings;
        
        public PersonJsonConverter(FormatType format = FormatType.Indent)
        {
            _settings = new JsonSerializerSettings();
            _settings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
            _settings.Formatting = format switch
            {
                FormatType.None => Formatting.None,
                _ => Formatting.Indented
            };
        }
        
        public string Serialize(Person person)
        {
            var result = JsonConvert.SerializeObject(person, _settings);
            return result;
        }
    }
}