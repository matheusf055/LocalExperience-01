using LocalExperience.AppServices.Trips.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalExperience.AppServices.Users.DTOs
{
    public class UserWithTripsDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public List<TripDto> Trips { get; set; }
    }
}
