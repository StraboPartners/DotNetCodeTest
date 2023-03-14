using FluentValidation;

namespace ApplicationCore.DataModel;

public class PriceValidator : AbstractValidator<Price>
{
	public PriceValidator()
	{
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
	}
}