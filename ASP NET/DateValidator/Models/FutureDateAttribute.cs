using System;
using System.ComponentModel.DataAnnotations;

namespace DateValidator.Models
{
    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || !(value is DateTime))
            {
                return new ValidationResult("Invalid date format.");
            }

            DateTime submittedDate = (DateTime)value;

            if (submittedDate > DateTime.Now)
            {
                return new ValidationResult("Date cannot be in the future.");
            }

            return ValidationResult.Success;
        }
    }
}
