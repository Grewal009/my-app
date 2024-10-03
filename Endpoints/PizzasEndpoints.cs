using pizza.api.Entities;
using pizza.api.Repositories;

namespace pizza.api.Endpoints;

public static class PizzasEndpoints
{
    const string pizzaEndpointName = "getPizzaById";

    public static RouteGroupBuilder MapPizzasEndpoints(this IEndpointRouteBuilder routes)
    {

        var group = routes.MapGroup("/pizzas.no").WithParameterValidation();

        group.MapGet("/", (IPizzasRepository repository) => repository.GetAll().Select(p => p.AsDto()));

        group.MapGet("/{id}", (IPizzasRepository repository, int id) =>
        {
            Pizza? pizza = repository.GetById(id);
            return pizza == null ? Results.NotFound() : Results.Ok(pizza.AsDto());

        }).WithName(pizzaEndpointName);

        group.MapPost("/", (IPizzasRepository repository, CreatePizzaDto createPizzaDto) =>
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
            repository.Create(pizza);

            return Results.CreatedAtRoute(pizzaEndpointName, new { id = pizza.Id }, pizza);
        });

        group.MapPut("/{id}", (IPizzasRepository repository, int id, UpdatePizzaDto updatedPizzaDto) =>
        {
            Pizza? pizza = repository.GetById(id);
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

            repository.Update(pizza);

            return Results.NoContent();

        });

        group.MapDelete("/{id}", (IPizzasRepository repository, int id) =>
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