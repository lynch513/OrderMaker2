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
  ""Name"": ""Иванов И.И."",
  ""AdditionalName"": ""Иванову И.И."",
  ""Group"": ""Three"",
  ""Speciality"": ""тракторист"",
  ""Posts"": [
    ""Member""
  ]
}";

            var converter = new PersonJsonConverter();
            var personJson = converter.Serialize(person);
            personJson.Should().BeEquivalentTo(personString);
        }
    }
}