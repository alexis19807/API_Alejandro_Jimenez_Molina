using Application.ScoreWeigths.Create;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Application.Validators
{
	public class AddWeigthsValidator : AbstractValidator<AddWeigthsCommand>
	{
		private readonly Regex Regex = new Regex(@"^[0-9]+$");

		public AddWeigthsValidator()
		{
			RuleFor(x => x.snatch.ToString())
				.Matches(Regex)
				.WithMessage("Only numbers are allowed");

			RuleFor(x => x.jerk.ToString())
				.Matches(Regex)
				.WithMessage("Only numbers are allowed");

			RuleFor(x => x.sportman)
				.NotEmpty()
				.WithMessage("Sportman id is required");
		}
	}
}
