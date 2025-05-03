using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalExperience.AppServices.Trips.DTOs
{
    public class TripsInterestProfileUpdateDto
    {
        public Guid TripId { get; set; }
        public int CultureInterest { get; set; }
        public int NatureInterest { get; set; }
        public int GastronomyInterest { get; set; }
        public int NightlifeInterest { get; set; }
        public int ShoppingInterest { get; set; }
    }
}
