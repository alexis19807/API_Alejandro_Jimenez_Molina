namespace Domain.SportMen
{
	public interface ISportManRepository
	{
		Task<ICollection<SportMan>> GetAll();
		Task CreateSportMan(SportMan sportMan);
	}
}
