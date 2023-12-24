using Application.ScoreWeigths.Create;
using Application.Sportman.Create;
using Application.Sportman.GetAll;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API_Alejandro_Jimenez_Molina.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class SportManController : ControllerBase
	{
		private IValidator<CreateSportmanCommand> _validator;
		private readonly ILogger<SportManController> _logger;
		private readonly IMediator _mediator;

		public SportManController(ILogger<SportManController> logger,
			IMediator mediator,
			IValidator<CreateSportmanCommand> validator)
		{
			_logger = logger;
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
				return BadRequest(new { Errors = result.Errors.Select(x => x.ErrorMessage) });
			}

			await _mediator.Send(command);

			return Ok();
		}
	}
}