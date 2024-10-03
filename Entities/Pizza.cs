using System.ComponentModel.DataAnnotations;

namespace pizza.api.Entities;

public class Pizza
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public required string Name { get; set; }

    [Required]
    [Url]
    [StringLength(150)]
    public required string Image { get; set; }

    [Required]
    [StringLength(500)]
    public required string Ingredients { get; set; }

    [Required]
    [StringLength(100)]
    public required string Allergens { get; set; }

    [Range(50, 250)]
    public decimal RegularPrice { get; set; }

    [Range(200, 500)]
    public decimal LargePrice { get; set; }

    public bool Vegetarian { get; set; }

    public bool GlutenFree { get; set; }

}