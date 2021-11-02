using FluentAssertions;
using NUnit.Framework;
using OrderMaker.Models;

namespace OrderMaker.Converters.Tests
{
    public class PersonJsonConverterTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var person = new PersonBuilder()
                .SetName("Иванов И.И.")
                .SetAdditionalName("Иванову И.И.")
                .SetGroup(GroupType.Three)
                .SetSpeciality("тракторист")
                .IsMember
                .Build();

            var personString = @"{
  ""ФИО"": ""Иванов И.И."",
  ""ДопФИО"": ""Иванову И.И."",
  ""Группа"": ""3гр"",
  ""Специальность"": ""тракторист"",
  ""Должности"": [
    ""ЧленБригады""
  ]
}";

            var converter = new PersonJsonConverter();
            var personJson = converter.Serialize(person);
            personJson.Should().BeEquivalentTo(personString);
        }
    }
}