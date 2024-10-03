
using Microsoft.EntityFrameworkCore;
using pizza.api.Entities;

namespace pizza.api.Data.Configurations;

public class PizzaConfigurations : IEntityTypeConfiguration<Pizza>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Pizza> builder)
    {
        builder.Property(pizza => pizza.RegularPrice)
                .HasPrecision(5, 2);
        builder.Property(pizza => pizza.LargePrice)
                .HasPrecision(5, 2);
    }

}