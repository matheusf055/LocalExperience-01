using LocalExperience.AppServices.Auth;
using LocalExperience.AppServices.Interfaces.Auth;
using LocalExperience.AppServices.Interfaces.Itineraries;
using LocalExperience.AppServices.Interfaces.Preferences;
using LocalExperience.AppServices.Interfaces.Trips;
using LocalExperience.AppServices.Interfaces.Users;
using LocalExperience.AppServices.Itineraries;
using LocalExperience.AppServices.Preferences;
using LocalExperience.AppServices.Trips;
using LocalExperience.AppServices.Users;
using LocalExperience.Domain.Itineraries.Repositories;
using LocalExperience.Domain.Preferences.Repositories;
using LocalExperience.Domain.Trips.Repositories;
using LocalExperience.Domain.Users.Repositories;
using LocalExperience.Infrastructure.ExternalServices.ChatGpt;
using LocalExperience.Infrastructure.Persistence;
using LocalExperience.Infrastructure.Repositories.Itineraries;
using LocalExperience.Infrastructure.Repositories.Preferences;
using LocalExperience.Infrastructure.Repositories.Trips;
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
            services.AddScoped<IPreferencesRepository, PreferencesRepository>();
            services.AddScoped<IPreferencesAppService, PreferencesAppService>();
            services.AddScoped<IAuthAppService, AuthAppService>();

            services.AddHttpClient<ChatGptService>();
        }
    }
}
