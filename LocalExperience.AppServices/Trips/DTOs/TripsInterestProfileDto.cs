using System;
using LocalExperience.Domain.Trips;

namespace LocalExperience.AppServices.Trips.DTOs
{
    public class TripsInterestProfileDto
    {
        public Guid Id { get; set; }
        public Guid TripId { get; set; }
        public InterestLevel CultureInterest { get; set; }
        public InterestLevel NatureInterest { get; set; }
        public InterestLevel GastronomyInterest { get; set; }
        public InterestLevel NightlifeInterest { get; set; }
        public InterestLevel ShoppingInterest { get; set; }
    }
}