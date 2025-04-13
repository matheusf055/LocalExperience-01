using System;

namespace LocalExperience.AppServices.Interfaces.Trips.DTOs
{
    public class UpdateTripDto
    {
        public Guid Id { get; set; }
        public string Destination { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? ShareCode { get; set; }
        public UpdateTripsInterestProfileDto InterestProfile { get; set; }
    }
} 