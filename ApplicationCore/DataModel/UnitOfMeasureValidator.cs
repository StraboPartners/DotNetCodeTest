using System;
using FluentValidation;

namespace ApplicationCore.DataModel
{
	public class UnitOfMeasureValidator : AbstractValidator<UnitOfMeasure>
	{
		public UnitOfMeasureValidator()
		{
			RuleFor(unitOfMeasure => unitOfMeasure.Description)
				.NotEmpty();
			RuleFor(unitOfMeasure => unitOfMeasure.ExternalId)
				.MaximumLength(4);
		}
	}
}

