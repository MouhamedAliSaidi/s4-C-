using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginRegistrationProject.Models
{
public class User
{
    [Key]
    public int UserId { get; set; }

    [Required]
    [MinLength(2, ErrorMessage = "First name must be at least 2 characters.")]
    [MaxLength(255)] // ✅ Added
    public string FirstName { get; set; }

    [Required]
    [MinLength(2, ErrorMessage = "Last name must be at least 2 characters.")]
    [MaxLength(255)] // ✅ Added
    public string LastName { get; set; }

    [Required]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    [MaxLength(255)] // ✅ Added
    public string Email { get; set; }

    [Required]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters.")]
    [DataType(DataType.Password)]
    [MaxLength(255)] // ✅ Added
    public string Password { get; set; }

    [NotMapped]
    [Compare("Password", ErrorMessage = "Passwords do not match.")]
    [DataType(DataType.Password)]
    public string PasswordConfirm { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}

}