
using System.ComponentModel.DataAnnotations;

public record PizzaDto(
    int Id,
    string Name,
    string Image,
    string Ingredients,
    string Allergens,
    decimal RegularPrice,
    decimal LargePrice,
    bool Vegetarian,
    bool GlutenFree
);

public record CreatePizzaDto(
    [Required][StringLength(100)] string Name,
    [Required][Url][StringLength(150)] string Image,
    [Required][StringLength(500)] string Ingredients,
    [Required][StringLength(100)] string Allergens,
    [Range(50, 250)] decimal RegularPrice,
    [Range(200, 500)] decimal LargePrice,
    bool Vegetarian,
    bool GlutenFree
);

public record UpdatePizzaDto(
    [Required][StringLength(100)] string Name,
    [Required][Url][StringLength(150)] string Image,
    [Required][StringLength(500)] string Ingredients,
    [Required][StringLength(100)] string Allergens,
    [Range(50, 250)] decimal RegularPrice,
    [Range(200, 500)] decimal LargePrice,
    bool Vegetarian,
    bool GlutenFree
);