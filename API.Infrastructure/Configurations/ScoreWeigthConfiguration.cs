using Domain.ScoreWeigths;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
	public class ScoreWeigthConfiguration : IEntityTypeConfiguration<ScoreWeigth>
	{
		public void Configure(EntityTypeBuilder<ScoreWeigth> builder)
		{
			builder.ToTable(nameof(ScoreWeigth));
			builder.HasKey(s => s.Id);
			builder.Ignore(s => s.TotalWeigth);
			builder.HasOne(s => s.SportMan)
				.WithMany(s => s.ScoreWeigths)
				.HasForeignKey(s => s.SportManId)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
