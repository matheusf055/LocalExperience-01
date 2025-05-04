using LocalExperience.Domain.Common;
using LocalExperience.Domain.Trips;
using LocalExperience.Domain.Users;
using System;

namespace LocalExperience.Domain.Preferences
{
    public class Preference : BaseEntity
    {
        public Guid TripId { get; set; }
        public Trip Trip { get; set; }

        public InterestLevel CultureInterest { get; set; }
        public InterestLevel NatureInterest { get; set; }
        public InterestLevel GastronomyInterest { get; set; }
        public InterestLevel NightlifeInterest { get; set; }
        public InterestLevel ShoppingInterest { get; set; }

        public Preference() { }

        public Preference(Guid tripId, InterestLevel culture, InterestLevel nature, InterestLevel gastronomy, InterestLevel nightlife, InterestLevel shopping)
        {
            TripId = tripId;
            CultureInterest = culture;
            NatureInterest = nature;
            GastronomyInterest = gastronomy;
            NightlifeInterest = nightlife;
            ShoppingInterest = shopping;
        }

        public string GetInterestSummary()
        {
            return $"Cultura: {CultureInterest}, Natureza: {NatureInterest}, Gastronomia: {GastronomyInterest}, Noite: {NightlifeInterest}, Compras: {ShoppingInterest}";
        }
    }

    public enum InterestLevel
    {
        None = 1,
        Low = 2,
        Medium = 3,
        High = 4,
        VeryHigh = 5
    }
}
