using FluentValidation;

namespace ApplicationCore.Services;

public static class ValidatorExtensions
{
	public static Func<object, string, Task<IEnumerable<string>>> FormValidate<T>(this IValidator<T> validator)
	{
		return async (callingObject, property) =>
		{
			if (callingObject is not T model)
			{
				return Array.Empty<string>();
			}

			var results = await validator.ValidateAsync(
				ValidationContext<T>.CreateWithOptions(model, a => a.IncludeProperties(property)));

			return results.IsValid
				? Array.Empty<string>()
				: results.Errors.Select(e => e.ErrorMessage);
		};
	}
}