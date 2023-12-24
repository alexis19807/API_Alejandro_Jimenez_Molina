using Application.Sportman.Create;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Application.Validators
{
	public class CreateSportManValidator : AbstractValidator<CreateSportmanCommand>
	{
		private readonly Regex Regex = new Regex(@"^[0-9]*$");

		public CreateSportManValidator()
		{
			RuleFor(x => x.country)
				.NotEmpty()
				.MaximumLength(3)
				.WithMessage("Introduce a valid country");

			RuleFor(x => x.name)
				.NotEmpty()
				.MaximumLength(50)
				.WithMessage("Name is required");
		}
	}
}
