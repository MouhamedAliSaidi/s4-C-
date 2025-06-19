using System.ComponentModel.DataAnnotations;

namespace ChefsNDishes.Models;

public class Dish
{
    [Key]
    public int DishId { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public int Calories { get; set; }

    [Required]
    [Range(1, 5)]
    public int Tastiness { get; set; }

    [Required]
    public int ChefId { get; set; }

    public Chef? Chef { get; set; }
}
