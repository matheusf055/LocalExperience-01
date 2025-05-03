using LocalExperience.Domain.Trips;

namespace LocalExperience.AppServices.Trips.DTOs
{
    public class CreateTripsInterestProfileDto
    {
        public InterestLevel CultureInterest { get; set; }
        public InterestLevel NatureInterest { get; set; }
        public InterestLevel GastronomyInterest { get; set; }
        public InterestLevel NightlifeInterest { get; set; }
        public InterestLevel ShoppingInterest { get; set; }
    }
}