using ApplicationCore.Services;
using FluentValidation;

namespace ApplicationCore.DataModel;

public class PriceValidator : AbstractValidator<Price>
{
	private readonly IPriceService _priceService;
	public PriceValidator(IPriceService priceService)
	{
		_priceService = priceService;

		RuleFor(price => price.ProductId)
			.NotEmpty();

		RuleFor(price => price.PriceTypeName)
			.NotEmpty();

		RuleFor(price => price.UnitOfMeasureName)
			.NotEmpty();

		RuleFor(price => price.QuantityFrom)
			.GreaterThan(0)
			.When(price => price.QuantityFrom != default);

		RuleFor(price => price.QuantityTo)
			.GreaterThan(0)
			.When(price => price.QuantityFrom != default);

		RuleFor(price => price.QuantityTo)
			.GreaterThan(price => price.QuantityFrom)
			.When(price => price.QuantityFrom != default && price.QuantityTo != default);

		RuleFor(price => price)
			.MustAsync(async (price, cancellation) =>
			{
				var existingPrices = await _priceService.GetAllPrices();

				//Check to make sure From date comes before To date when creating a price date range
				if (price.ToDate < price.FromDate)
				{
					return false;
				}

				foreach (var existingPrice in existingPrices)
				{
					//If ProductId, Unit of Measure, and PriceTypeName all match, enure new price type does not have an overlapping price date range
					if (price.ProductId == existingPrice.ProductId && price.UnitOfMeasure == existingPrice.UnitOfMeasure && price.PriceTypeName == existingPrice.PriceTypeName)
					{
						if (IsOverlap(price, existingPrice))
						{
							return false;
						}
					}
				}

				return true;
			})
			.WithMessage("Price period overlaps with an existing price period for the same product or To Date comes before From Date");
	}

	private bool IsOverlap(Price price, Price existingPrice)
	{
		//Null means no value and we don't want to check nulls;
		if (existingPrice.FromDate == null && existingPrice.ToDate == null)
		{
			return false;
		}
		//Check for a price date range that begins before and ends after existing price range
		if (price.FromDate <= existingPrice.FromDate && price.ToDate >= existingPrice.ToDate)
		{
			return true;
		}
		//Check for price From date inside an existing price date range
		if (price.FromDate >= existingPrice.FromDate && price.FromDate <= existingPrice.ToDate)
		{
			return true;
		}

		//Check for price To date inside an existing price date range
		return (price.ToDate <= existingPrice.ToDate && price.ToDate >= existingPrice.FromDate);

	}
}