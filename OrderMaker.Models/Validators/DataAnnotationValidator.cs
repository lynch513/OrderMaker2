using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderMaker.Validators
{
    public static class DataAnnotationValidator
    {
        public static bool TryValidate<T>(T obj, out ICollection<ValidationResult> results)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            results = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, new ValidationContext(obj), results, true);
        }
    }
}