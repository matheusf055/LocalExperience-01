using System;

namespace LocalExperience.AppServices.Trips.DTOs
{
    public class CreateTripDto
    {
        public Guid UserId { get; set; }
        public string Destination { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}