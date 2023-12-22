namespace Domain.Data.Entities
{
	public class ScoreWeigth
	{
        public Guid Id { get; set; }
        //Arranque
        public int Snatch { get; set; }
		//Envion
		public int Jerk { get; set; }
		public int TotalWeigth { get; set; }
        public SportMan? SportMan { get; set; }
    }
}
