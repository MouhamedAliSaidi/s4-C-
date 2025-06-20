using System;
using System.ComponentModel.DataAnnotations;


public class FutureDateAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext context)
    {
        DateTime inputDate = Convert.ToDateTime(value);
        if (inputDate < DateTime.Now)
            return new ValidationResult("Date must be in the future.");
        return ValidationResult.Success;
    }
}
