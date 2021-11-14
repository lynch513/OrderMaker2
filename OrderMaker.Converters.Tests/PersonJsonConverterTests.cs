using AutoMapper;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using OrderMaker.Converters.DTO;
using OrderMaker.Models;

namespace OrderMaker.Converters.Tests
{
    public class PersonJsonConverterTests
    {
        private Person? _person;
        private string? _personString;
        private JsonConverter? _converter;
        
        [SetUp]
        public void Setup()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Person, PersonDto>();
                cfg.CreateMap<PersonDto, Person>();
            });
            var mapper = new Mapper(config);
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            };

            _converter = new JsonConverter(settings, mapper);
            
            _person = new PersonBuilder()
                .SetName("Иванов И.И.")
                .SetAdditionalName("Иванову И.И.")
                .SetGroup(GroupType.Three)
                .SetSpeciality("тракторист")
                .IsMember
                .Build();

            _personString = @"{
  ""ФИО"": ""Иванов И.И."",
  ""ДопФИО"": ""Иванову И.И."",
  ""Группа"": ""3гр"",
  ""Специальность"": ""тракторист"",
  ""Должности"": [
    ""ЧленБригады""
  ]
}";
        }

        [Test]
        public void PersonJsonConverter_Should_Serialize_Person()
        {
            var personJson = _converter?.Serialize<Person, PersonDto>(_person!);
            personJson.Should().BeEquivalentTo(_personString);
        }
        
        [Test]
        public void PersonJsonConverter_Should_Deserialize_Person()
        {
            var personResult = _converter?.Deserialize<Person, PersonDto>(_personString!);
            personResult.Should().BeEquivalentTo(_person);
        }
    }
}