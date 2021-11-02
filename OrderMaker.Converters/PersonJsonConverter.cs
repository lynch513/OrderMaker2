using System;
using System.Text.RegularExpressions;
using AutoMapper;
using Newtonsoft.Json;
using OrderMaker.Converters.DTO;
using OrderMaker.Models;

namespace OrderMaker.Converters
{
    public class PersonJsonConverter
    {
        private readonly JsonSerializerSettings _settings;
        private readonly Mapper _mapper;
        
        public PersonJsonConverter(FormatType format = FormatType.Indent)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Person, PersonDto>();
            });
            _mapper = new Mapper(config);
            _settings = new JsonSerializerSettings();
            // _settings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
            _settings.NullValueHandling = NullValueHandling.Ignore;
            _settings.Formatting = format switch
            {
                FormatType.None => Formatting.None,
                _ => Formatting.Indented
            };
        }
        
        public string Serialize(Person person)
        {
            var personDto = _mapper.Map<PersonDto>(person);
            var result = JsonConvert.SerializeObject(personDto, _settings);
            return result;
        }
    }
}