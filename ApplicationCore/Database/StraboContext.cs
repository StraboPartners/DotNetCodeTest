using System.Reflection;
using ApplicationCore.DataModel;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Database;

public sealed class StraboContext : DbContext
{
	public StraboContext(DbContextOptions<StraboContext> options) : base(options) { }

	public DbSet<Product> Products { get; set; } = null!;

	public DbSet<UnitOfMeasure> UnitsOfMeasure { get; set; } = null!;
	public DbSet<Price> Prices { get; set; } = null!;
	public DbSet<PriceType> PriceTypes { get; set; } = null!;

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
	}
}