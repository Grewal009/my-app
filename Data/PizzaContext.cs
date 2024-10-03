
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using pizza.api.Entities;

namespace pizza.api.Data;

public class PizzaContext : DbContext
{
    public PizzaContext(DbContextOptions<PizzaContext> options) : base(options)
    {

    }

    public DbSet<Pizza> Pizzas => Set<Pizza>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }


}