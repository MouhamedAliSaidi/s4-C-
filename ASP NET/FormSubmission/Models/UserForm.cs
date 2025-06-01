using System;
using System.ComponentModel.DataAnnotations;
using FormSubmission.Validations;

namespace FormSubmission.Models
{
    public class UserForm
    {
        [Required(ErrorMessage = "Name is required.")]
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Must be a valid email address.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Date of Birth is required.")]
        [PastDate(ErrorMessage = "Date of Birth must be in the past.")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters.")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Favorite Number is required.")]
        [OddNumber(ErrorMessage = "Favorite number must be an odd number.")]
        public int FavoriteNumber { get; set; }
    }
}
