
using pizza.api.Entities;

List<Pizza> pizzaList = new(){
    new Pizza(){Id= 1,Name= "Heavy Heaven",Image= "https://www.peppes.no/bilder_webshop/0130.jpg",Ingredients="Pepperoni, garlic-spiced meatballs, marinated beef, red onion and oregano",Allergens= "Wheat, Gluten, Milk",RegularPrice= 100,LargePrice= 310,Vegetarian= false,GlutenFree= false},
    new Pizza(){Id= 2,Name= "Chicken Flyaway",Image= "https://www.peppes.no/bilder_webshop/0119.jpg",Ingredients= "Marinated chicken, corn, leek and red pepper",Allergens= "Wheat, Gluten, Milk",RegularPrice= 110,LargePrice= 298,Vegetarian= false,GlutenFree= false},
    new Pizza(){Id= 3,Name= "Oh My Garden!",Image= "https://www.peppes.no/bilder_webshop/0141.jpg",Ingredients= "Avocado, red onion, marinated aromatic mushrooms, olives, cherry tomatoes and kale mix. The cheese has been replaced with a tasty vegan aioli. Topped with freshly ground pepper and lime zest",Allergens= "Wheat, Gluten, Milk",RegularPrice= 115,LargePrice= 310,Vegetarian= true,GlutenFree= false},
    new Pizza(){Id= 4,Name= "Green Garden",Image= "https://www.peppes.no/bilder_webshop/0147.jpg",Ingredients=  "Avocado, red onion, marinated aromatic mushrooms, olives, cherry tomatoes, kale mix, fresh mozzarella and Peppe's cheese mixture. Topped with freshly ground pepper and lime zest",Allergens= "Wheat, Gluten, Milk",RegularPrice= 110,LargePrice= 310,Vegetarian= true,GlutenFree= false},
    new Pizza(){Id= 5,Name= "GLUTEN-FREE Chicken Flyaway",Image= "https://www.peppes.no/bilder_webshop/0319.jpg",Ingredients= "Marinated chicken, corn, leek and red pepper",Allergens= "Soya, Milk",RegularPrice= 115,LargePrice= 350,Vegetarian= false,GlutenFree= true},
    };

const string pizzaEndpointName = "getPizzaById";



var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

var group = app.MapGroup("/pizzas.no");

group.MapGet("/", () => pizzaList);

group.MapGet("/{id}", (int id) =>
{
    Pizza? pizza = pizzaList.Find(p => p.Id == id);
    if (pizza == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(pizza);
}).WithName(pizzaEndpointName);

group.MapPost("/", (Pizza pizza) =>
{
    pizza.Id = pizzaList.Max(p => p.Id) + 1;
    pizzaList.Add(pizza);

    return Results.CreatedAtRoute(pizzaEndpointName, new { id = pizza.Id }, pizza);
});

group.MapPut("/{id}", (int id, Pizza updatedPizza) =>
{
    Pizza? pizza = pizzaList.Find(p => p.Id == id);
    if (pizza == null)
    {
        return Results.NotFound();
    }

    pizza.Name = updatedPizza.Name;
    pizza.Image = updatedPizza.Image;
    pizza.Ingredients = updatedPizza.Ingredients;
    pizza.Allergens = updatedPizza.Allergens;
    pizza.RegularPrice = updatedPizza.RegularPrice;
    pizza.LargePrice = updatedPizza.LargePrice;
    pizza.Vegetarian = updatedPizza.Vegetarian;
    pizza.GlutenFree = updatedPizza.GlutenFree;

    return Results.NoContent();

});

group.MapDelete("/{id}", (int id) =>
{
    Pizza? pizza = pizzaList.Find(p => p.Id == id);
    if (pizza is not null)
    {
        pizzaList.Remove(pizza);
    }

    return Results.NoContent();
});

app.Run();
