using MediatR;

namespace Application.ScoreWeigths.Create
{
	public record AddWeigthsCommand(int snatch, int jerk, Guid sportman) : IRequest<Unit>;
}
