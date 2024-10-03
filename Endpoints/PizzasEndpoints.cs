using pizza.api.Entities;
using pizza.api.Repositories;

namespace pizza.api.Endpoints;

public static class PizzasEndpoints
{
    const string pizzaEndpointName = "getPizzaById";

    public static RouteGroupBuilder MapPizzasEndpoints(this IEndpointRouteBuilder routes)
    {

        var group = routes.MapGroup("/pizzas.no").WithParameterValidation();

        group.MapGet("/", async (IPizzasRepository repository) => (await repository.GetAllAsync()).Select(p => p.AsDto()));

        group.MapGet("/{id}", async (IPizzasRepository repository, int id) =>
        {
            Pizza? pizza = await repository.GetByIdAsync(id);
            return pizza == null ? Results.NotFound() : Results.Ok(pizza.AsDto());

        }).WithName(pizzaEndpointName);

        group.MapPost("/", async (IPizzasRepository repository, CreatePizzaDto createPizzaDto) =>
        {
            Pizza pizza = new()
            {
                Name = createPizzaDto.Name,
                Image = createPizzaDto.Image,
                Ingredients = createPizzaDto.Ingredients,
                Allergens = createPizzaDto.Allergens,
                RegularPrice = createPizzaDto.RegularPrice,
                LargePrice = createPizzaDto.LargePrice,
                Vegetarian = createPizzaDto.Vegetarian,
                GlutenFree = createPizzaDto.GlutenFree
            };
            await repository.CreateAsync(pizza);

            return Results.CreatedAtRoute(pizzaEndpointName, new { id = pizza.Id }, pizza);
        });

        group.MapPut("/{id}", async (IPizzasRepository repository, int id, UpdatePizzaDto updatedPizzaDto) =>
        {
            Pizza? pizza = await repository.GetByIdAsync(id);
            if (pizza == null)
            {
                return Results.NotFound();
            }

            pizza.Name = updatedPizzaDto.Name;
            pizza.Image = updatedPizzaDto.Image;
            pizza.Ingredients = updatedPizzaDto.Ingredients;
            pizza.Allergens = updatedPizzaDto.Allergens;
            pizza.RegularPrice = updatedPizzaDto.RegularPrice;
            pizza.LargePrice = updatedPizzaDto.LargePrice;
            pizza.Vegetarian = updatedPizzaDto.Vegetarian;
            pizza.GlutenFree = updatedPizzaDto.GlutenFree;

            await repository.UpdateAsync(pizza);

            return Results.NoContent();

        });

        group.MapDelete("/{id}", async (IPizzasRepository repository, int id) =>
        {
            Pizza? pizza = await repository.GetByIdAsync(id);
            if (pizza is not null)
            {
                await repository.DeleteAsync(id);
            }

            return Results.NoContent();
        });

        return group;

    }


}