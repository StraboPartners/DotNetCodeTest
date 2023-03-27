using ApplicationCore.Database;
using ApplicationCore.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

	public Task<UnitOfMeasure> GetUnitOfMeasureAsync(long unitOfMeasureId)
		=> _unitOfMeasureDbAccess.GetUnitOfMeasureAsync(unitOfMeasureId);

	public Task<UnitOfMeasure> CreateUnitOfMeasureAsync(UnitOfMeasure unitOfMeasure)
		=> _unitOfMeasureDbAccess.CreateUnitOfMeasureAsync(unitOfMeasure);

	public Task<UnitOfMeasure> UpdateUnitOfMeasureAsync(UnitOfMeasure unitOfMeasure)
		=> _unitOfMeasureDbAccess.UpdateUnitOfMeasureAsync(unitOfMeasure);

	public Task<int> DeleteUnitsOfMeasureAsync(HashSet<long> unitOfMeasureIds)
		=> _unitOfMeasureDbAccess.DeleteUnitsOfMeasureAsync(unitOfMeasureIds);
}
