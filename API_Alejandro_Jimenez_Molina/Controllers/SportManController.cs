using Application.Sportman.Create;
using Application.Sportman.GetAll;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Text;

namespace API_Alejandro_Jimenez_Molina.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	[Authorize]
	public class SportManController : ControllerBase
	{
		private IValidator<CreateSportmanCommand> _validator;
		private readonly IMediator _mediator;

		public SportManController(IMediator mediator,
			IValidator<CreateSportmanCommand> validator)
		{
			_mediator = mediator;
			_validator = validator;
		}

		[HttpGet]
		public async Task<IActionResult> SportManList()
		{
			var result = await _mediator.Send(new GetSportMenQuery());

			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> SaveSportMan([FromBody] CreateSportmanCommand command)
		{
			var result = await _validator.ValidateAsync(command);

			if (!result.IsValid)
			{
				var stringBuilder = new StringBuilder();
				stringBuilder.AppendLine($"Error creating sportman");

				foreach (var error in result.Errors)
				{
					stringBuilder.AppendLine(error.ErrorMessage);
				}

				return BadRequest(new { Errors = result.Errors.Select(x => x.ErrorMessage) });
			}

			var guid = await _mediator.Send(command);
			Log.Information($"Sportman created with Guid {guid}");

			return Ok(new { SportmanId = guid });
		}
	}
}