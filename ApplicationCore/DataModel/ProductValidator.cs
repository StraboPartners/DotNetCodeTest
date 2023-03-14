using FluentValidation;

namespace ApplicationCore.DataModel;

public class ProductValidator : AbstractValidator<Product>
{
	public ProductValidator()
	{
		RuleFor(product => product.ProductNumber)
			.NotEmpty()
			.MaximumLength(48);

		RuleFor(product => product.Name)
			.MaximumLength(80);

		RuleFor(product => product.UnitOfMeasureName)
			.NotEmpty();
	}
}