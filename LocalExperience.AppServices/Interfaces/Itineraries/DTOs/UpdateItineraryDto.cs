using System;

namespace LocalExperience.AppServices.Interfaces.Itineraries.DTOs
{
    public class UpdateItineraryDto
    {
        public Guid Id { get; set; }
        public Guid TripId { get; set; }
        public string Summary { get; set; }
    }
}