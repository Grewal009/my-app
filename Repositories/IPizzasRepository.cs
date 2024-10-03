using pizza.api.Entities;

namespace pizza.api.Repositories;

public interface IPizzasRepository
{
    IEnumerable<Pizza> GetAll();
    Pizza? GetById(int id);
    void Create(Pizza pizza);
    void Update(Pizza updatedPizza);
    void Delete(int id);
}