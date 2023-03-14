using ApplicationCore.Database;
using ApplicationCore.DataModel;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Services;

public class ProductDbAccess : IProductDbAccess
{
	private readonly IDbContextFactory<StraboContext> _dbContextFactory;
	
	public ProductDbAccess(IDbContextFactory<StraboContext> dbContextFactory)
	{
		_dbContextFactory = dbContextFactory;
	}
	public async Task<List<Product>> GetAllProductsAsync()
	{
		await using var context = await _dbContextFactory.CreateDbContextAsync();
		return await context.Products
			.OrderBy(product => product.Id)
			.ToListAsync();
	}

	public async Task<Product> GetProductAsync(long productId)
	{
		await using var context = await _dbContextFactory.CreateDbContextAsync();
		return await context.Products.SingleAsync(product => product.Id == productId);
	}

	public async Task<Product> CreateProductAsync(Product product)
	{
		await using var context = await _dbContextFactory.CreateDbContextAsync();
		context.Products.Add(product);
		await context.SaveChangesAsync();
		return product;
	}

	public async Task<Product> UpdateProductAsync(Product product)
	{
		await using var context = await _dbContextFactory.CreateDbContextAsync();
		context.Update(product);
		await context.SaveChangesAsync();
		return product;
	}

	public async Task<int> DeleteProductsAsync(HashSet<long> productIds)
	{
		await using var context = await _dbContextFactory.CreateDbContextAsync();
		return await context.Products
			.Where(product => productIds.Contains(product.Id))
			.ExecuteDeleteAsync();
	}
}