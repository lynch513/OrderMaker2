using FluentAssertions;
using NUnit.Framework;
using OrderMaker.Converters.DTO;
using OrderMaker.Models;

namespace OrderMaker.Converters.Tests
{
    public class PersonJsonConverterTests
    {
        private Person _person;
        private string _personString;
        
        [SetUp]
        public void Setup()
        {
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
            var converter = new JsonConverter<Person, PersonDto>();
            var personJson = converter.Serialize(_person);
            personJson.Should().BeEquivalentTo(_personString);
        }
        
        [Test]
        public void PersonJsonConverter_Should_Deserialize_Person()
        {
            var converter = new JsonConverter<Person, PersonDto>();
            var personResult = converter.Deserialize(_personString);
            personResult.Should().BeEquivalentTo(_person);
        }
    }
}