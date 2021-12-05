using System;
using System.ComponentModel.DataAnnotations;
using OrderMaker.Models.Checkers;

namespace OrderMaker.Models.Attributes
{
    public class PostsAttribute : ValidationAttribute
    {
        private static string GetErrorMessage() =>
            "Несоответствие указанной должности";

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            var person = (Person) validationContext.ObjectInstance;
            var personChecker = new PersonChecker(person);

            var errorMessage = personChecker.ErrorMessage == null
                ? GetErrorMessage()
                : $"{GetErrorMessage()}: {personChecker.ErrorMessage}";

            return personChecker.IsValid ? ValidationResult.Success : new ValidationResult(errorMessage);
        }
    }
}