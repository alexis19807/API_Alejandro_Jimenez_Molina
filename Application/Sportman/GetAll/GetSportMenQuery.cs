using MediatR;

namespace Application.Sportman.GetAll
{
	public record GetSportMenQuery() : IRequest<ICollection<GetSportManQueryResponse>>;
}
