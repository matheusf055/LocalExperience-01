using LocalExperience.Domain.Trips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalExperience.AppServices.Trips.DTOs
{
    public class TripsInterestProfileCreateDto
    {
        public Guid TripId { get; set; }
        public InterestLevel CultureInterest { get; set; }
        public InterestLevel NatureInterest { get; set; }
        public InterestLevel GastronomyInterest { get; set; }
        public InterestLevel NightlifeInterest { get; set; }
        public InterestLevel ShoppingInterest { get; set; }
    }
}
