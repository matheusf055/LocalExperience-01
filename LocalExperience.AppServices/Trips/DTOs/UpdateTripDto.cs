using System;

namespace LocalExperience.AppServices.Trips.DTOs
{
    public class UpdateTripDto
    {
        public Guid Id { get; set; }
        public string Destination { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}