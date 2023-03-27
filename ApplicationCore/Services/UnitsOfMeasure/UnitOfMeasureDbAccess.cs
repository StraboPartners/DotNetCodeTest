using ApplicationCore.Database;
using ApplicationCore.DataModel;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Services;

	public class UnitOfMeasureDbAccess : IUnitOfMeasureDbAccess
	{
		private readonly IDbContextFactory<StraboContext> _dbContextFactory;

		public UnitOfMeasureDbAccess(IDbContextFactory<StraboContext> dbContextFactory)
		{
			_dbContextFactory = dbContextFactory;
		}
		public async Task<List<UnitOfMeasure>> GetAllUnitsOfMeasureAsync()
		{
			await using var context = await _dbContextFactory.CreateDbContextAsync();
			return await context.UnitsOfMeasure
				.OrderBy(unitOfMeasure => unitOfMeasure.Id)
				.ToListAsync();
		}

		public async Task<UnitOfMeasure> GetUnitOfMeasureAsync(long unitOfMeasureId)
		{
			await using var context = await _dbContextFactory.CreateDbContextAsync();
			return await context.UnitsOfMeasure.SingleAsync(unitOfMeasure => unitOfMeasure.Id == unitOfMeasureId);
		}

		public async Task<UnitOfMeasure> CreateUnitOfMeasureAsync(UnitOfMeasure unitOfMeasure)
		{
			await using var context = await _dbContextFactory.CreateDbContextAsync();
			context.UnitsOfMeasure.Add(unitOfMeasure);
			await context.SaveChangesAsync();
			return unitOfMeasure;
		}

		public async Task<UnitOfMeasure> UpdateUnitOfMeasureAsync(UnitOfMeasure unitOfMeasure)
		{
			await using var context = await _dbContextFactory.CreateDbContextAsync();
			context.Update(unitOfMeasure);
			await context.SaveChangesAsync();
			return unitOfMeasure;
		}

		public async Task<int> DeleteUnitsOfMeasureAsync(HashSet<long> unitOfMeasureIds)
		{
			await using var context = await _dbContextFactory.CreateDbContextAsync();
			return await context.UnitsOfMeasure
				.Where(unitOfMeasure => unitOfMeasureIds.Contains(unitOfMeasure.Id))
				.ExecuteDeleteAsync();
		}
	}