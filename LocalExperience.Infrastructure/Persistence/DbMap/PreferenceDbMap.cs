using LocalExperience.Domain.Preferences;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocalExperience.Infrastructure.Persistence.DbMap
{
    public class PreferenceDbMap : IEntityTypeConfiguration<Preference>
    {
        public void Configure(EntityTypeBuilder<Preference> builder)
        {
            builder.ToTable("TravelInterestProfiles");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.CultureInterest)
                .IsRequired();

            builder.Property(p => p.NatureInterest)
                .IsRequired();

            builder.Property(p => p.GastronomyInterest)
                .IsRequired();

            builder.Property(p => p.NightlifeInterest)
                .IsRequired();

            builder.Property(p => p.ShoppingInterest)
                .IsRequired();

            builder.HasOne(p => p.Trip)
                   .WithOne(t => t.Preference)
                   .HasForeignKey<Preference>(p => p.TripId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
