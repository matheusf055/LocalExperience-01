using LocalExperience.AppServices.Interfaces.Itineraries.DTOs;
using LocalExperience.AppServices.Interfaces.Trips.DTOs;
using LocalExperience.Domain.Trips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalExperience.AppServices.Mappers.Trips
{
    public class TripMapper
    {
        public static TripDto ConvertTripWithDetails(Trip trip)
        {
            return new TripDto
            {
                Id = trip.Id,
                UserId = trip.UserId,
                Destination = trip.Destination,
                StartDate = trip.StartDate,
                EndDate = trip.EndDate,
                ShareCode = trip.ShareCode,
                CreateDate = trip.CreateDate,
                Itineraries = trip.Itineraries.Select(i => new ItineraryDto
                {
                    Id = i.Id,
                    TripId = i.TripId,
                    Summary = i.Summary,
                    CreateDate = i.CreateDate
                }).ToList(),

                TripsInterestProfile = new TripsInterestProfileDto
                {
                    Id = trip.TripsInterestProfile.Id,
                    TripId = trip.TripsInterestProfile.TripId,
                    CultureInterest = trip.TripsInterestProfile.CultureInterest,
                    ShoppingInterest = trip.TripsInterestProfile.ShoppingInterest,
                    NatureInterest = trip.TripsInterestProfile.NatureInterest,
                    GastronomyInterest = trip.TripsInterestProfile.GastronomyInterest,
                    NightlifeInterest = trip.TripsInterestProfile.NightlifeInterest
                }
            };
        }
    }
}
