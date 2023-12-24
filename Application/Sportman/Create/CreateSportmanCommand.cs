using MediatR;

namespace Application.Sportman.Create
{
	//We use record because its inmutable and its better for DTOs in CQRS
	public record CreateSportmanCommand(string country, string name) : IRequest<Unit>;
}
