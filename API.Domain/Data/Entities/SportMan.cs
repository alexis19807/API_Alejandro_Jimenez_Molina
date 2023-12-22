namespace Domain.Data.Entities
{
	public class SportMan
	{
		public Guid Id { get; set; }
		public string? Country { get; set; }
		public string? Name { get; set; }
        public ICollection<ScoreWeigth> Weigths { get; set; }
    }
}
