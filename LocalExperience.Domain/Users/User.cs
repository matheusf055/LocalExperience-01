using LocalExperience.Domain.Common;
using LocalExperience.Domain.Trips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalExperience.Domain.Users
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public List<Trip> Trips { get; set; } = new();
        public DateTime CreateDate { get; set; }

        public User() { }

        public User(string email, string name)
        {
            Email = email;
            Name = name;
            CreateDate = DateTime.UtcNow;
        }
    }
}
