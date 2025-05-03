using System;

namespace LocalExperience.AppServices.Itineraries.DTOs
{
    public class CreateItineraryDto
    {
        public Guid TripId { get; set; }
        public string Summary { get; set; }
    }
}