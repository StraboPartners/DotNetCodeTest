using System;
using System.IO;
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

        var context = await _dbContextFactory.CreateDbContextAsync();
        var result = await context.UnitsOfMeasure.OrderBy(uom => uom.Name).ToListAsync();

        return result;
    }

    public async Task<UnitOfMeasure> CreateUnitOfMeasure(UnitOfMeasure uom)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        context.UnitsOfMeasure.Add(uom);
        await context.SaveChangesAsync();
        return uom;
    }

    public async Task<UnitOfMeasure> UpdateUnitOfMeasure(UnitOfMeasure uom)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        context.UnitsOfMeasure.Update(uom);
        await context.SaveChangesAsync();
        return uom;
    }
    public async Task<int> DeleteUnitsOfMeasure(HashSet<long> uomIds)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        return await context.UnitsOfMeasure
            .Where(uom => uomIds.Contains(uom.Id))
            .ExecuteDeleteAsync();
    }

}

