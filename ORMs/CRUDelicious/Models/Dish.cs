using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


public class Dish
{
    [Key]
    public int DishId { get; set; }

    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Chef is required")]
    public string Chef { get; set; }

    [Required(ErrorMessage = "Calories are required")]
    [Range(1, int.MaxValue, ErrorMessage = "Calories must be greater than 0")]
    public int Calories { get; set; }

    [Required(ErrorMessage = "Tastiness is required")]
    [Range(1, 5, ErrorMessage = "Tastiness must be between 1 and 5")]
    public int Tastiness { get; set; }

    [Required(ErrorMessage = "Description is required")]
    public string Description { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
