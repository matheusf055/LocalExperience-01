using LocalExperience.Domain.Common;
using LocalExperience.Domain.Trips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalExperience.Domain.Itineraries
{
    public class Itinerary : BaseEntity
    {
        public Guid TripId { get; set; }
        public Trip Trip { get; set; }
        public string Summary { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;

        public Itinerary() { }

        public Itinerary(Guid tripId, string summary)
        {
            TripId = tripId;
            Summary = summary;
        }
    }
}
