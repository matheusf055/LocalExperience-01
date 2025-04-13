using LocalExperience.AppServices.Interfaces.Itineraries.DTOs;
using LocalExperience.AppServices.Interfaces.Trips.DTOs;
using LocalExperience.AppServices.Interfaces.Users.DTOs;
using LocalExperience.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalExperience.AppServices.Mappers.Users
{
    public class UserMapper
    {
        public static UserWithTripsDto ConvertUserWithTripsDto(User user)
        {
            return new UserWithTripsDto
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                CreateDate = user.CreateDate,
                Trips = user.Trips.Select(t => new TripDto
                {
                    Id = t.Id,
                    UserId = t.UserId,
                    Destination = t.Destination,
                    ShareCode = t.ShareCode,
                    StartDate = t.StartDate,
                    EndDate = t.EndDate,
                    CreateDate = t.CreateDate,
                    Itineraries = t.Itineraries.Select(i => new ItineraryDto
                    {
                        Id = i.Id,
                        TripId = i.TripId,
                        Summary = i.Summary,
                        CreateDate = i.CreateDate
                    }).ToList(),

                    TripsInterestProfile = new TripsInterestProfileDto
                    {
                        Id = t.TripsInterestProfile.Id,
                        TripId = t.TripsInterestProfile.TripId,
                        CultureInterest = t.TripsInterestProfile.CultureInterest,
                        ShoppingInterest = t.TripsInterestProfile.ShoppingInterest,
                        NatureInterest = t.TripsInterestProfile.NatureInterest,
                        GastronomyInterest = t.TripsInterestProfile.GastronomyInterest,
                        NightlifeInterest = t.TripsInterestProfile.NightlifeInterest
                    }
                }).ToList()
            };
        }
    }
}
