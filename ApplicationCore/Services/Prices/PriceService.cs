using ApplicationCore.DataModel;

namespace ApplicationCore.Services;

public class PriceService : IPriceService
{
	IPriceDbAccess _priceDbAccess;
	
	public PriceService(IPriceDbAccess priceDbAccess)
	{
		_priceDbAccess = priceDbAccess;
	}

	public Task<List<Price>> GetAllPrices() 
		=> _priceDbAccess.GetAllPrices();

	public Task<Price> CreatePrice(Price price) 
		=> _priceDbAccess.CreatePrice(price);

	public Task<Price> UpdatePrice(Price price) 
		=> _priceDbAccess.UpdatePrice(price);

	public Task<int> DeletePrices(HashSet<long> priceIds) 
		=> _priceDbAccess.DeletePrices(priceIds);

	public Task<List<PriceType>> GetAllPriceTypes() => _priceDbAccess.GetAllPriceTypes();

	public Task<PriceType> CreatePriceType(PriceType priceType) => _priceDbAccess.CreatePriceType(priceType);

	public Task<PriceType> UpdatePriceType(PriceType priceType) => _priceDbAccess.UpdatePriceType(priceType);

	public Task<int> DeletePriceTypes(HashSet<long> priceTypeIds) => _priceDbAccess.DeletePriceTypes(priceTypeIds);
}