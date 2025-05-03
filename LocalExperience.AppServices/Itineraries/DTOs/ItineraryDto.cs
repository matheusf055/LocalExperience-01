using System;

namespace LocalExperience.AppServices.Itineraries.DTOs
{
    public class ItineraryDto
    {
        public Guid Id { get; set; }
        public Guid TripId { get; set; }
        public string Summary { get; set; }
        public DateTime CreateDate { get; set; }
    }
}