using Application.ScoreWeigths.Create;
using Application.Sportman.Create;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Text;

namespace API_Alejandro_Jimenez_Molina.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class ScoreWeigthsController : ControllerBase
	{
		private readonly IMediator _mediator;
		private IValidator<AddWeigthsCommand> _validator;

		public ScoreWeigthsController(IMediator mediator,
			IValidator<AddWeigthsCommand> validator)
		{
			_mediator = mediator;
			_validator = validator;
		}


		[HttpPost]
		public async Task<IActionResult> SaveWeigths([FromBody] AddWeigthsCommand command)
		{
			var result = await _validator.ValidateAsync(command);

			if (!result.IsValid)
			{
				var stringBuilder = new StringBuilder();
				stringBuilder.AppendLine($"Error adding weigths");

				foreach(var error in result.Errors) 
				{
					stringBuilder.AppendLine(error.ErrorMessage);
				}

				return BadRequest(new { Errors = result.Errors.Select(x => x.ErrorMessage) });
			}

			await _mediator.Send(command);
			Log.Information($"Weigths added for sportman with Guid {command.sportman}");

			return Ok();
		}
	}
}
