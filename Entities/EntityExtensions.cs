
namespace pizza.api.Entities;

public static class EntityExtensions
{
    public static PizzaDto AsDto(this Pizza pizza)
    {
        return new PizzaDto(pizza.Id, pizza.Name, pizza.Image, pizza.Ingredients, pizza.Allergens, pizza.RegularPrice, pizza.LargePrice, pizza.Vegetarian, pizza.GlutenFree);
    }


}