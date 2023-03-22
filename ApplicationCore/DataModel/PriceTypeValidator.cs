using FluentValidation;

namespace ApplicationCore.DataModel;

public class PriceTypeValidator : AbstractValidator<PriceType>
{
	public PriceTypeValidator()
	{
		RuleFor(priceType => priceType.Name)
			.NotEmpty()
			.MaximumLength(20);

		RuleFor(priceType => priceType.Description)
			.MaximumLength(80);

		RuleFor(priceType => priceType.ExternalId)
			.MaximumLength(8);
	}
}