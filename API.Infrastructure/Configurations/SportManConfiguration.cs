using Domain.SportMen;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
	public class SportManConfiguration : IEntityTypeConfiguration<SportMan>
	{
		public void Configure(EntityTypeBuilder<SportMan> builder)
		{
			builder.ToTable(nameof(SportMan));
			builder.HasKey(s => s.Id);
			builder.Property(s => s.Name).HasMaxLength(50);
			builder.Property(s => s.Country).HasMaxLength(3);
		}
	}
}
