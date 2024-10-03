
using Microsoft.EntityFrameworkCore;
using pizza.api.Data;
using pizza.api.Entities;

namespace pizza.api.Repositories;

public class EntityFrameworkPizzaRepository : IPizzasRepository
{
    PizzaContext dbContext;

    public EntityFrameworkPizzaRepository(PizzaContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public IEnumerable<Pizza> GetAll()
    {
        return dbContext.Pizzas.AsNoTracking().ToList();
    }

    public Pizza? GetById(int id)
    {
        return dbContext.Pizzas.Find(id);
    }

    public void Create(Pizza pizza)
    {
        dbContext.Pizzas.Add(pizza);
        dbContext.SaveChanges();
    }

    public void Update(Pizza updatedPizza)
    {
        dbContext.Update(updatedPizza);
        dbContext.SaveChanges();
    }

    public void Delete(int id)
    {
        dbContext.Pizzas.Where(p => p.Id == id).ExecuteDelete();
    }

}