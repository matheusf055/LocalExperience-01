using LocalExperience.Domain.Common;
using LocalExperience.Domain.Itineraries;
using LocalExperience.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalExperience.Domain.Trips
{
    public class Trip : BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; } 
        public string Destination { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? ShareCode { get; set; }
        public DateTime CreateDate { get; set; }
        public List<Itinerary> Itineraries { get; set; } = new();

        public Trip() { }

        public Trip(Guid userId, string destination, DateTime startDate, DateTime endDate, string? shareCode)
        {
            if (string.IsNullOrWhiteSpace(destination))
                throw new ArgumentException("Destino é obrigatório.");

            if (startDate > endDate)
                throw new ArgumentException("A data de início não pode ser depois da data de término.");

            UserId = userId;
            Destination = destination;
            StartDate = startDate;
            EndDate = endDate;
            ShareCode = shareCode;
            CreateDate = DateTime.UtcNow;
        }
    }
}
