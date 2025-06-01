using System;
using System.ComponentModel.DataAnnotations;

namespace FormSubmission.Validations
{
    public class PastDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is DateTime date)
            {
                return date < DateTime.Now;
            }
            return false;
        }
    }
}
