using System;
using ApplicationCore.Database;
using ApplicationCore.DataModel;

namespace ApplicationCore.Services;

public class UnitOfMeasureService : IUnitOfMeasureService
{
	private readonly IUnitOfMeasureDbAccess _unitOfMeasureDbAccess;
	public UnitOfMeasureService(IUnitOfMeasureDbAccess unitOfMeasureDbAccess)
	{
		_unitOfMeasureDbAccess = unitOfMeasureDbAccess;
	}

	public Task<List<UnitOfMeasure>> GetAllUnitsOfMeasureAsync()
		=> _unitOfMeasureDbAccess.GetAllUnitsOfMeasureAsync();

	public Task<UnitOfMeasure> CreateUnitOfMeasure(UnitOfMeasure uom)
		=> _unitOfMeasureDbAccess.CreateUnitOfMeasure(uom);

	public Task<UnitOfMeasure> UpdateUnitOfMeasure(UnitOfMeasure uom)
		=> _unitOfMeasureDbAccess.UpdateUnitOfMeasure(uom);

    public Task<int> DeleteUnitsOfMeasure(HashSet<long> uomIds)
        => _unitOfMeasureDbAccess.DeleteUnitsOfMeasure(uomIds);
}

