using Application.ScoreWeigths.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API_Alejandro_Jimenez_Molina.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ScoreWeigthsController : ControllerBase
	{
		private readonly ILogger<SportManController> _logger;
		private readonly IMediator _mediator;

		public ScoreWeigthsController(ILogger<SportManController> logger,
			IMediator mediator)
		{
			_logger = logger;
			_mediator = mediator;
		}


		[HttpPost]
		public async Task<IActionResult> SaveWeigths([FromBody] AddWeigthsCommand command)
		{
			//var result = await _validator.ValidateAsync(command);

			/*if (!result.IsValid)
			{
				return BadRequest(new { Errors = result.Errors.Select(x => x.ErrorMessage) });
			}*/

			await _mediator.Send(command);

			return Ok();
		}
	}
}
