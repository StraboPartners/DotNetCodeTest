using ApplicationCore.DataModel;


namespace ApplicationCore.Database;
public interface IUnitOfMeasureDbAccess
{
	Task<List<UnitOfMeasure>> GetAllUnitsOfMeasureAsync();
	Task<UnitOfMeasure> GetUnitOfMeasureAsync(long unitOfMeasureId);
	Task<UnitOfMeasure> CreateUnitOfMeasureAsync(UnitOfMeasure unitOfMeasure);
	Task<UnitOfMeasure> UpdateUnitOfMeasureAsync(UnitOfMeasure unitOfMeasure);
	Task<int> DeleteUnitsOfMeasureAsync(HashSet<long> unitOfmeasureIds);
}

