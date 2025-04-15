using LocalExperience.AppServices.Interfaces.Itineraries;
using LocalExperience.AppServices.Interfaces.Trips;
using LocalExperience.AppServices.Interfaces.TripsInterestProfiles;
using LocalExperience.AppServices.Interfaces.Users;
using LocalExperience.AppServices.Itineraries;
using LocalExperience.AppServices.Trips;
using LocalExperience.AppServices.Users;
using LocalExperience.Domain.Itineraries.Repositories;
using LocalExperience.Domain.Trips.Repositories;
using LocalExperience.Domain.Users.Repositories;
using LocalExperience.Infrastructure.ExternalServices.ChatGpt;
using LocalExperience.Infrastructure.Persistence;
using LocalExperience.Infrastructure.Repositories.Itineraries;
using LocalExperience.Infrastructure.Repositories.Trips;
using LocalExperience.Infrastructure.Repositories.TripsInterestProfiles;
using LocalExperience.Infrastructure.Repositories.Users;
using Microsoft.EntityFrameworkCore;

namespace LocalExperience.Api.DI
{
    public class DependencyInjection
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LocalExperienceDbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserAppService, UserAppService>();
            services.AddScoped<ITripRepository, TripRepository>();
            services.AddScoped<ITripAppService, TripAppService>();
            services.AddScoped<IItineraryRepository, ItineraryRepository>();
            services.AddScoped<IItineraryAppService, ItineraryAppService>();
            services.AddScoped<ITripsInterestProfileRepository, TripsInterestProfileRepository>();
            services.AddScoped<ITripsInterestProfileAppService, TripsInterestProfileAppService>();

            services.AddHttpClient<ChatGptService>();
        }
    }
}
