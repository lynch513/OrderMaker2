using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using OrderMaker.Models;
using OrderMaker.Validators;

namespace OrderMaker.UnitTests.Validators
{
    public class DataAnnotationsForPersonTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Should_Validate_Name_Exist()
        {
            const string message = @"Поле ""ФИО"" является обязательным";
            var sut = new Person();

            var resultFlag = DataAnnotationValidator.TryValidate(sut, out var results);
            var result = results.Select(i => i.ErrorMessage).FirstOrDefault();
            
            resultFlag.Should().BeFalse();
            result.Should().BeEquivalentTo(message);
        }
        
        [Test]
        public void Should_Validate_Name_Length()
        {
            const string message = @"Превышена допустимая длина поля ""ФИО""";
            var sut = new Person
            {
                Name = new string('a', 101)
            };

            var resultFlag = DataAnnotationValidator.TryValidate(sut, out var results);
            var result = results.Select(i => i.ErrorMessage).FirstOrDefault();
            
            resultFlag.Should().BeFalse();
            result.Should().BeEquivalentTo(message);
        }
    }
}
