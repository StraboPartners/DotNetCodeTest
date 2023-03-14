using ApplicationCore.DataModel;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ApplicationCore.Database;

public sealed class AppContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<Product> Products { get; set; } = null!;

    public DbSet<UnitOfMeasure> UnitsOfMeasure { get; set; } = null!;
    public DbSet<Price> Prices { get; set; } = null!;
    public DbSet<PriceType> PriceTypes { get; set; } = null!;
}
