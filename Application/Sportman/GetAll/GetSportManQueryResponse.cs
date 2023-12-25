using Domain.ScoreWeigths;

namespace Application.Sportman.GetAll
{
	public class GetSportManQueryResponse
	{
        public Guid Id { get; set; }
        public string Country { get; set; }
		public string Name { get; set; }
		//Arranque
		public int Snatch { get; set; }
		//Envion
		public int Jerk { get; set; }
		public int TotalWeigth => Snatch + Jerk;
	}
}
