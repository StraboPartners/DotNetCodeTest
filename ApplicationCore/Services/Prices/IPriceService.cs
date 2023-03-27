using ApplicationCore.DataModel;
using System.Threading.Tasks;

namespace ApplicationCore.Services;

public interface IPriceService
{
	Task<List<Price>> GetAllPrices();
	Task<Price> CreatePrice(Price price);
	Task<Price> UpdatePrice(Price price);
	Task<int> DeletePrices(HashSet<long> priceIds);

	Task<List<PriceType>> GetAllPriceTypes();
	Task<PriceType> CreatePriceType(PriceType priceType);
	Task<PriceType> UpdatePriceType(PriceType priceType);
	Task<int> DeletePriceTypes(HashSet<long> priceTypeIds);

	Task<List<UnitOfMeasure>> GetAllUnitsOfMeasure();
	Task<UnitOfMeasure> CreateUnitOfMeasure(UnitOfMeasure unitOfMeasure);
	Task<UnitOfMeasure> UpdateUnitOfMeasure(UnitOfMeasure unitOfMeasure);
	Task<int> DeleteUnitsOfMeasure(HashSet<long> unitOfMeasureIds);
}