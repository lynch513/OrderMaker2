using FluentAssertions;
using NUnit.Framework;
using OrderMaker.Models;
using OrderMaker.Models.Utils;

namespace OrderMaker.UnitTests.Extensions
{
    public class PersonStringExtensionsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PersonWithNameAndWithoutGroup_Should_Convert_ToString()
        {
            const string name = "Иванов И.И.";
            
            var person = new PersonBuilder()
                .SetName(name)
                .Build();

            person.GetNameWithGroup().Should().Be(name);
        }
        
        [Test]
        public void PersonWithNameAndWithGroup_Should_Convert_ToString()
        {
            const string name = "Иванов И.И.";
            const string groupString = "3 гр.";
            const GroupType group = GroupType.Three;
            
            var person = new PersonBuilder()
                .SetName(name)
                .SetGroup(group)
                .Build();

            person.GetNameWithGroup().Should().Be($"{name} {groupString}");
        }

        [Test]
        public void PersonWithNameAndWithoutAdditionalName_Should_Convert_ToString()
        {
            const string name = "Иванов И.И.";
            
            var person = new PersonBuilder()
                .SetName(name)
                .Build();

            person.GetAdditionalNameOrName().Should().Be(name);
        }
        
        [Test]
        public void PersonWithNameAndWithAdditionalName_Should_Convert_ToString()
        {
            const string name = "Иванов И.И.";
            const string additionalName = "Иванову И.И.";
            
            var person = new PersonBuilder()
                .SetName(name)
                .SetAdditionalName(additionalName)
                .Build();

            person.GetAdditionalNameOrName().Should().Be(additionalName);
        }
        
        [Test]
        public void PersonWithNameAndAdditionalNameWithoutGroup_Should_Convert_ToString()
        {
            const string name = "Иванов И.И.";
            const string additionalName = "Иванову И.И.";
            
            var person = new PersonBuilder()
                .SetName(name)
                .SetAdditionalName(additionalName)
                .Build();

            person.GetAdditionalNameOrNameWithGroup().Should().Be(additionalName);
        }
        
        [Test]
        public void PersonWithNameAndAdditionalNameWithGroup_Should_Convert_ToString()
        {
            const string name = "Иванов И.И.";
            const string additionalName = "Иванову И.И.";
            const GroupType group = GroupType.Three;
            const string groupString = "3 гр.";
            
            var person = new PersonBuilder()
                .SetName(name)
                .SetAdditionalName(additionalName)
                .SetGroup(group)
                .Build();

            person.GetAdditionalNameOrNameWithGroup().Should().Be($"{additionalName} {groupString}");
        }
        
        [Test]
        public void PersonWithNameGroupAndWithoutSpeciality_Should_Convert_ToString()
        {
            const string name = "Иванов И.И.";
            const GroupType group = GroupType.Three;
            const string groupString = "3 гр.";
            
            var person = new PersonBuilder()
                .SetName(name)
                .SetGroup(group)
                .Build();

            person.GetNameWithGroupAndSpeciality().Should().Be($"{name} {groupString}");
        }
        
        [Test]
        public void PersonWithNameGroupAndWithSpeciality_Should_Convert_ToString()
        {
            const string name = "Иванов И.И.";
            const GroupType group = GroupType.Three;
            const string speciality = "тракторист";
            const string groupString = "3 гр.";
            
            var person = new PersonBuilder()
                .SetName(name)
                .SetGroup(group)
                .SetSpeciality(speciality)
                .Build();

            person.GetNameWithGroupAndSpeciality().Should().Be($"{name} {groupString} ({speciality})");
        }
        
        [Test]
        public void PersonWithoutSpecialityAndNameGroup_Should_Convert_ToString()
        {
            const string name = "Иванов И.И.";
            const GroupType group = GroupType.Three;
            const string groupString = "3 гр.";
            
            var person = new PersonBuilder()
                .SetName(name)
                .SetGroup(group)
                .Build();

            person.GetSpecialityWithNameAndGroup().Should().Be($"{name} {groupString}");
        }
        
        [Test]
        public void PersonWithSpecialityAndNameGroup_Should_Convert_ToString()
        {
            const string name = "Иванов И.И.";
            const GroupType group = GroupType.Three;
            const string speciality = "тракторист";
            const string groupString = "3 гр.";
            
            var person = new PersonBuilder()
                .SetName(name)
                .SetGroup(group)
                .SetSpeciality(speciality)
                .Build();

            person.GetSpecialityWithNameAndGroup().Should().Be($"{speciality} {name} {groupString}");
        }
        
        [Test]
        public void PersonWithAdditionalNameGroupAndWithoutSpeciality_Should_Convert_ToString()
        {
            const string name = "Иванов И.И.";
            const string additionalName = "Иванову И.И.";
            const GroupType group = GroupType.Three;
            const string groupString = "3 гр.";
            
            var person = new PersonBuilder()
                .SetName(name)
                .SetAdditionalName(additionalName)
                .SetGroup(group)
                .Build();

            person.GetAdditionalNameWithGroupAndSpeciality().Should().Be($"{additionalName} {groupString}");
        }
        
        [Test]
        public void PersonWithAdditionalNameGroupAndWithSpeciality_Should_Convert_ToString()
        {
            const string name = "Иванов И.И.";
            const string additionalName = "Иванову И.И.";
            const GroupType group = GroupType.Three;
            const string speciality = "тракторист";
            const string groupString = "3 гр.";
            
            var person = new PersonBuilder()
                .SetName(name)
                .SetAdditionalName(additionalName)
                .SetGroup(group)
                .SetSpeciality(speciality)
                .Build();

            person.GetAdditionalNameWithGroupAndSpeciality().Should().Be($"{additionalName} {groupString} ({speciality})");
        }
        
    }
}