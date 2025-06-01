using System;
using System.ComponentModel.DataAnnotations;

namespace FormSubmission.Validations
{
    public class OddNumberAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is int number)
            {
                return number % 2 != 0;
            }
            return false;
        }
    }
}
