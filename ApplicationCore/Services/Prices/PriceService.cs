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

	public Task<List<PriceType>> GetAllPriceTypes()
		=> _priceDbAccess.GetAllPriceTypes();

	public Task<PriceType> CreatePriceType(PriceType priceType)
		=> _priceDbAccess.CreatePriceType(priceType);

	public Task<PriceType> UpdatePriceType(PriceType priceType)
		=> _priceDbAccess.UpdatePriceType(priceType);

	public Task<int> DeletePriceTypes(HashSet<long> priceTypeIds)
		=> _priceDbAccess.DeletePriceTypes(priceTypeIds);

	public Task<List<UnitOfMeasure>> GetAllUnitsOfMeasure()
		=> _priceDbAccess.GetAllUnitsOfMeasure();

	public Task<UnitOfMeasure> CreateUnitOfMeasure(UnitOfMeasure unitOfMeasure)
		=> _priceDbAccess.CreateUnitOfMeasure(unitOfMeasure);

	public Task<UnitOfMeasure> UpdateUnitOfMeasure(UnitOfMeasure unitOfMeasure)
		=> _priceDbAccess.UpdateUnitOfMeasure(unitOfMeasure);

	public Task<int> DeleteUnitsOfMeasure(HashSet<long> unitOfMeasureIds)
		=> _priceDbAccess.DeleteUnitsOfMeasure(unitOfMeasureIds);
}