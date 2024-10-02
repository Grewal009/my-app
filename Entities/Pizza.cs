

namespace pizza.api.Entities;

public class Pizza
{

    public int Id { get; set; }

    public required string Name { get; set; }

    public required string Image { get; set; }

    public required string Ingredients { get; set; }

    public required string Allergens { get; set; }

    public decimal RegularPrice { get; set; }

    public decimal LargePrice { get; set; }

    public bool Vegetarian { get; set; }

    public bool GlutenFree { get; set; }

}