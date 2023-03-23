using ApplicationCore.DataModel;

namespace ApplicationCore.Services;

public interface IUnitOfMeasureService
{
    Task<UnitOfMeasure> CreateUnitOfMeasure(UnitOfMeasure uom);
    Task<List<UnitOfMeasure>> GetAllUnitsOfMeasureAsync();
    Task<int> DeleteUnitsOfMeasure(HashSet<long> uomIds);
    Task<UnitOfMeasure> UpdateUnitOfMeasure(UnitOfMeasure uom);
}