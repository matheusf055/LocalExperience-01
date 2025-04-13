using System;
using LocalExperience.Domain.Trips;

namespace LocalExperience.AppServices.Interfaces.Trips.DTOs
{
    public class UpdateTripsInterestProfileDto
    {
        public Guid Id { get; set; }
        public InterestLevel CultureInterest { get; set; }
        public InterestLevel NatureInterest { get; set; }
        public InterestLevel GastronomyInterest { get; set; }
        public InterestLevel NightlifeInterest { get; set; }
        public InterestLevel ShoppingInterest { get; set; }
    }
} 