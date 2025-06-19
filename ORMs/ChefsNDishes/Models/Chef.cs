using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChefsNDishes.Models;

public class Chef
{
    [Key]
    public int ChefId { get; set; }

    [Required]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Date)]
    [Display(Name = "Date of Birth")]
    [CustomValidation(typeof(Chef), nameof(ValidateAge))]
    public DateTime DateOfBirth { get; set; }

    public static ValidationResult? ValidateAge(DateTime date, ValidationContext context)
    {
        int age = DateTime.Now.Year - date.Year;
        if (date > DateTime.Now.AddYears(-age)) age--;
        return age < 18
            ? new ValidationResult("Chef must be at least 18 years old.")
            : ValidationResult.Success;
    }

    public List<Dish> CreatedDishes { get; set; } = new();
}
