
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

    public async Task<IEnumerable<Pizza>> GetAllAsync()
    {
        return await dbContext.Pizzas.AsNoTracking().ToListAsync();
    }

    public async Task<Pizza?> GetByIdAsync(int id)
    {
        return await dbContext.Pizzas.FindAsync(id);
    }

    public async Task CreateAsync(Pizza pizza)
    {
        dbContext.Pizzas.Add(pizza);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Pizza updatedPizza)
    {
        dbContext.Update(updatedPizza);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await dbContext.Pizzas.Where(p => p.Id == id).ExecuteDeleteAsync();
    }


}