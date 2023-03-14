using ApplicationCore.Database;
using ApplicationCore.DataModel;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Services;

public class PriceDbAccess : IPriceDbAccess
{
	private readonly IDbContextFactory<StraboContext> _dbContextFactory;
	
	public PriceDbAccess(IDbContextFactory<StraboContext> dbContextFactory)
	{
		_dbContextFactory = dbContextFactory;
	}

	public async Task<List<Price>> GetAllPrices()
	{
		await using var context = await _dbContextFactory.CreateDbContextAsync();
		return await context.Prices
			.OrderBy(price => price.Id)
			.ToListAsync();
	}

	public async Task<Price> CreatePrice(Price price)
	{
		await using var context = await _dbContextFactory.CreateDbContextAsync();
		context.Prices.Add(price);
		await context.SaveChangesAsync();
		return price;
	}

	public async Task<Price> UpdatePrice(Price price)
	{
		await using var context = await _dbContextFactory.CreateDbContextAsync();
		context.Prices.Update(price);
		await context.SaveChangesAsync();
		return price;
	}

	public async Task<int> DeletePrices(HashSet<long> priceIds)
	{
		await using var context = await _dbContextFactory.CreateDbContextAsync();
		return await context.Prices
			.Where(price => priceIds.Contains(price.Id))
			.ExecuteDeleteAsync();
	}

	public async Task<List<PriceType>> GetAllPriceTypes()
	{
		var context = await _dbContextFactory.CreateDbContextAsync();
		return await context.PriceTypes.OrderBy(priceType => priceType.Name).ToListAsync();
	}

	public async Task<PriceType> CreatePriceType(PriceType priceType)
	{
		await using var context = await _dbContextFactory.CreateDbContextAsync();
		context.PriceTypes.Add(priceType);
		await context.SaveChangesAsync();
		return priceType;
	}

	public async Task<PriceType> UpdatePriceType(PriceType priceType)
	{
		await using var context = await _dbContextFactory.CreateDbContextAsync();
		context.PriceTypes.Update(priceType);
		await context.SaveChangesAsync();
		return priceType;
	}

	public async Task<int> DeletePriceTypes(HashSet<long> priceTypeIds)
	{
		await using var context = await _dbContextFactory.CreateDbContextAsync();
		return await context.PriceTypes
			.Where(priceType => priceTypeIds.Contains(priceType.Id))
			.ExecuteDeleteAsync();
	}
}