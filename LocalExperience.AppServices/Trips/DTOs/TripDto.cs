using System;
using System.Collections.Generic;
using LocalExperience.AppServices.Itineraries.DTOs;

namespace LocalExperience.AppServices.Trips.DTOs
{
    public class TripDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Destination { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ShareCode { get; set; }
        public DateTime CreateDate { get; set; }
        public List<ItineraryDto> Itineraries { get; set; }
        public TripsInterestProfileDto TripsInterestProfile { get; set; }
    }
}