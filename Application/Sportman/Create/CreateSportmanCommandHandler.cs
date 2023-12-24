using Domain.Primitives;
using Domain.ScoreWeigths;
using Domain.SportMen;
using MediatR;

namespace Application.Sportman.Create
{
    //Use CQRS with MediatR to have a layer for each operation to the database(insert. select...etc):This is for create SportMan
    public class CreateSportmanCommandHandler : IRequestHandler<CreateSportmanCommand, Unit>
	{
		private readonly ISportManRepository _sportManRepository;
		private readonly IUnitOfWork _unitOfWork;

		public CreateSportmanCommandHandler(ISportManRepository sportManRepository, IUnitOfWork unitOfWork)
		{
			_sportManRepository = sportManRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<Unit> Handle(CreateSportmanCommand command, CancellationToken cancellationToken)
		{
			var sportMan = new SportMan()
			{
				Id = new Guid(),
				Name = command.name,
				Country = command.country,
			};

			await this._sportManRepository.CreateSportMan(sportMan);

			await _unitOfWork.SaveChangesAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
