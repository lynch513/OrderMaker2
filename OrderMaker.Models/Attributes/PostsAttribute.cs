using System;
using System.ComponentModel.DataAnnotations;
using OrderMaker.Models.Validators;

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
            var personChecker = new PersonValidator(person);
            var result = personChecker.TryValidate(out var message);

            var errorMessage = message == null ? GetErrorMessage() : $"{GetErrorMessage()}: {message}";

            return result ? ValidationResult.Success : new ValidationResult(errorMessage);
        }
    }
}