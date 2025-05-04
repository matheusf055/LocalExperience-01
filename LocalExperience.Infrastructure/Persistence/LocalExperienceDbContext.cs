using LocalExperience.Domain.Itineraries;
using LocalExperience.Domain.Preferences;
using LocalExperience.Domain.Trips;
using LocalExperience.Domain.Users;
using LocalExperience.Infrastructure.Persistence.DbMap;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalExperience.Infrastructure.Persistence
{
    public class LocalExperienceDbContext : DbContext
    {
        public LocalExperienceDbContext(DbContextOptions<LocalExperienceDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Itinerary> Itineraries { get; set; }
        public DbSet<Preference> preference { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserDbMap());
            modelBuilder.ApplyConfiguration(new TripDbMap());
            modelBuilder.ApplyConfiguration(new ItineraryDbMap());
            modelBuilder.ApplyConfiguration(new preferenceDbMap());
        }
    }
}
