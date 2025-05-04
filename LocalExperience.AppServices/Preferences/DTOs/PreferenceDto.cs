using LocalExperience.Domain.Preferences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalExperience.AppServices.Preferences.DTOs
{
    public class PreferenceDto
    {
        public Guid TripId { get; set; }
        public InterestLevel CultureInterest { get; set; }
        public InterestLevel NatureInterest { get; set; }
        public InterestLevel GastronomyInterest { get; set; }
        public InterestLevel NightlifeInterest { get; set; }
        public InterestLevel ShoppingInterest { get; set; }
    }
}
