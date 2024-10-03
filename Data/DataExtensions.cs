
using Microsoft.EntityFrameworkCore;

namespace pizza.api.Data;

public static class DataExtensions
{
    public static async Task InitializeDbAsync(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<PizzaContext>();
        await dbContext.Database.MigrateAsync();
    }




}