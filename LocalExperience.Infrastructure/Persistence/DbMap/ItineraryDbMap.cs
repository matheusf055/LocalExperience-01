using LocalExperience.Domain.Itineraries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalExperience.Infrastructure.Persistence.DbMap
{
    public class ItineraryDbMap : IEntityTypeConfiguration<Itinerary>
    {
        public void Configure(EntityTypeBuilder<Itinerary> builder)
        {
            builder.ToTable("Itineraries");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Summary)
                .IsRequired()
                .HasMaxLength(2000);

            builder.HasOne(i => i.Trip)
                .WithMany(t => t.Itineraries)
                .HasForeignKey(i => i.TripId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
