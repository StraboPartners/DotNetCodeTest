using ApplicationCore.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services;
public interface IUnitOfMeasureService
{
	Task<List<UnitOfMeasure>> GetAllUnitsOfMeasureAsync();
	Task<UnitOfMeasure> GetUnitOfMeasureAsync(long unitOfMeasureId);
	Task<UnitOfMeasure> CreateUnitOfMeasureAsync(UnitOfMeasure unitOfMeasure);
	Task<UnitOfMeasure> UpdateUnitOfMeasureAsync(UnitOfMeasure unitOfMeasure);
	Task<int> DeleteUnitsOfMeasureAsync(HashSet<long> unitOfmeasureIds);
}
