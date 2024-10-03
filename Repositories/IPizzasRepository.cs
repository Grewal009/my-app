using pizza.api.Entities;

namespace pizza.api.Repositories;

public interface IPizzasRepository
{
    Task<IEnumerable<Pizza>> GetAllAsync();
    Task<Pizza?> GetByIdAsync(int id);
    Task CreateAsync(Pizza pizza);
    Task UpdateAsync(Pizza updatedPizza);
    Task DeleteAsync(int id);
}