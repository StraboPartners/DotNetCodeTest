using FluentValidation;

namespace ApplicationCore.DataModel;

public class UnitOfMeasureValidator : AbstractValidator<UnitOfMeasure>
{
	public UnitOfMeasureValidator()
	{
		RuleFor(unitOfMeasure => unitOfMeasure.Name)
			.NotEmpty()
			.MaximumLength(20);

		RuleFor(unitOfMeasure => unitOfMeasure.Description)
			.MaximumLength(80);

		RuleFor(unitOfMeasure => unitOfMeasure.ExternalId)
			.MaximumLength(4);
	}
}