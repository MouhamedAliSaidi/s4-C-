using System;
using System.ComponentModel.DataAnnotations;

namespace DateValidator.Models
{
    public class Person
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [FutureDate(ErrorMessage = "Date must be in the past.")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
    }
}
