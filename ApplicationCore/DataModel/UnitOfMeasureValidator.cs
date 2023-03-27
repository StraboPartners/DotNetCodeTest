using FluentValidation;

namespace ApplicationCore.DataModel;

public class UnitOfMeasureValidator : AbstractValidator<UnitOfMeasure>
{
    public UnitOfMeasureValidator()
    {
        RuleFor(unitOfMeasure => unitOfMeasure.Name)
            .NotEmpty()
            .MaximumLength(48);

        RuleFor(unitOfMeasure => unitOfMeasure.Description)
            .MaximumLength(80);

        RuleFor(product => product.ExternalId)
            .MaximumLength(4);
    }
}