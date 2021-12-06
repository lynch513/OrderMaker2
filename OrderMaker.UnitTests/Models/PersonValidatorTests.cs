using FluentAssertions;
using NUnit.Framework;
using OrderMaker.Models;
using OrderMaker.Models.Validators;

namespace OrderMaker.UnitTests.Models
{
    [TestFixture]
    public class PersonValidatorTests
    {
        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void Should_With_Empty_Person_Return_True()
        {
            var person = new Person();
            var sut = new PersonValidator(person);

            var resultFlag = sut.TryValidate(out var message);

            resultFlag.Should().BeTrue();
            message.Should().BeNull();
        }

        [TestCase(GroupType.Two, PostType.Member, true, null)]
        [TestCase(GroupType.Two, PostType.Watcher, false, "не может быть наблюдающим")]
        [TestCase(GroupType.Three, PostType.Watcher, true, null)]
        [TestCase(GroupType.Two, PostType.Maker, false, "не может быть производителем работ")]
        [TestCase(GroupType.Three, PostType.Maker, true, null)]
        [TestCase(GroupType.Two, PostType.Admitter, false, "не может быть допускающим")]
        [TestCase(GroupType.Three, PostType.Admitter, true, null)]
        [TestCase(GroupType.Two, PostType.Supervisor, false, "не может быть ответственным руководителем работ")]
        [TestCase(GroupType.Three, PostType.Supervisor, true, null)]
        [TestCase(GroupType.Two, PostType.Dispatcher, false,
            "не может быть выдающим разрешение на подготовку рабочих мест и на допуск")]
        [TestCase(GroupType.Three, PostType.Dispatcher, true, null)]
        [TestCase(GroupType.Three, PostType.Issuer, false, "не может быть выдающим наряд")]
        [TestCase(GroupType.Four, PostType.Issuer, true, null)]
        public void Should_Validate_Person(GroupType groupType, PostType postType, bool expectedResult,
            string? expectedMessage)
        {
            var person = new PersonBuilder()
                .SetGroup(groupType)
                .AddPost(postType)
                .Build();

            var sut = new PersonValidator(person);

            var resultFlag = sut.TryValidate(out var message);

            resultFlag.Should().Be(expectedResult);
            message.Should().BeEquivalentTo(expectedMessage);
        }
    }
}