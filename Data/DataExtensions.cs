
using Microsoft.EntityFrameworkCore;

namespace pizza.api.Data;

public static class DataExtensions
{
    public static void InitializeDb(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<PizzaContext>();
        dbContext.Database.Migrate();
    }




}