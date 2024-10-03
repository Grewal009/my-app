using pizza.api.Entities;
using pizza.api.Repositories;

namespace pizza.api.Endpoints;

public static class PizzasEndpoints
{
    const string pizzaEndpointName = "getPizzaById";
    
    public static RouteGroupBuilder MapPizzasEndpoints(this IEndpointRouteBuilder routes)
    {
        
        var group = routes.MapGroup("/pizzas.no").WithParameterValidation();

        group.MapGet("/", (IPizzasRepository repository) => repository.GetAll());

        group.MapGet("/{id}", (IPizzasRepository repository,int id) =>
        {
            Pizza? pizza = repository.GetById(id);
            return pizza == null ? Results.NotFound() : Results.Ok(pizza);
            
        }).WithName(pizzaEndpointName);

        group.MapPost("/", (IPizzasRepository repository,Pizza pizza) =>
        {
            repository.Create(pizza);

            return Results.CreatedAtRoute(pizzaEndpointName, new { id = pizza.Id }, pizza);
        });

        group.MapPut("/{id}", (IPizzasRepository repository,int id, Pizza updatedPizza) =>
        {
            Pizza? pizza = repository.GetById(id);
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
            
            repository.Update(pizza);

            return Results.NoContent();

        });

        group.MapDelete("/{id}", (IPizzasRepository repository,int id) =>
        {
            Pizza? pizza = repository.GetById(id);
            if (pizza is not null)
            {
                repository.Delete(id);
            }

            return Results.NoContent();
        });

        return group;

    }


}