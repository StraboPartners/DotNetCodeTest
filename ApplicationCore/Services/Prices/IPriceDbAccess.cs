using ApplicationCore.DataModel;

namespace ApplicationCore.Services;

public interface IPriceDbAccess
{
	Task<List<Price>> GetAllPrices();
	Task<Price> CreatePrice(Price price);
	Task<Price> UpdatePrice(Price price);
	Task<int> DeletePrices(HashSet<long> priceIds);

	Task<List<PriceType>> GetAllPriceTypes();
	Task<PriceType> CreatePriceType(PriceType priceType);
	Task<PriceType> UpdatePriceType(PriceType priceType);
	Task<int> DeletePriceTypes(HashSet<long> priceTypeIds);
}