using System.ComponentModel.DataAnnotations;
using FluentAssertions;
using NUnit.Framework;
using OrderMaker.Extensions;

namespace OrderMaker.UnitTests.Extensions
{
    public class ReflectionExtensionsTests
    {
        public enum TestEnum
        {
            [Display(Name = "One item")]
            One,
            [Display(Name = "Two item")]
            Two,
            [Display(Name = "Three item")]
            Three,
            Five
        }
        
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(TestEnum.One, "One item")]
        [TestCase(TestEnum.Two, "Two item")]
        [TestCase(TestEnum.Three, "Three item")]
        [TestCase(TestEnum.Five, "Five")]
        public void GetDisplayAttribute_On_Enum_Return_Value(TestEnum enumValue, string expected)
        {
            var result = enumValue.GetDisplayNameAttribute();
            result.Should().BeEquivalentTo(expected);
        }
    }
}
