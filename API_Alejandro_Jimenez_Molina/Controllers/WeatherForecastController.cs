using Domain.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API_Alejandro_Jimenez_Molina.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class MainController : ControllerBase
	{
		private static readonly string[] Summaries = new[]
		{
		"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
	};

		private readonly ILogger<MainController> _logger;

		public MainController(ILogger<MainController> logger)
		{
			_logger = logger;
		}

		[HttpGet]
		public IEnumerable<SportMan> SportMans()
		{
			return null;
		}

		[HttpGet]
		public SportMan SportManById()
		{
			return null;
		}

		[HttpPost]
		public Guid SaveSportMan()
		{
			return new Guid();
		}

		[HttpPut]
		public SportMan UpdateSportMan()
		{
			return new SportMan();
		}

		[HttpDelete]
		public SportMan DeleteSportMan()
		{
			return new SportMan();
		}
	}
}