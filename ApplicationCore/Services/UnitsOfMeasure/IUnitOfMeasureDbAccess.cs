using ApplicationCore.DataModel;

namespace ApplicationCore.Services; 

public interface IUnitOfMeasureDbAccess
{
    Task<List<UnitOfMeasure>> GetAllUnitsOfMeasureAsync();
    Task<UnitOfMeasure> CreateUnitOfMeasure(UnitOfMeasure uom);
    Task<UnitOfMeasure> UpdateUnitOfMeasure(UnitOfMeasure uom);
    Task<int> DeleteUnitsOfMeasure(HashSet<long> uomIds);

}