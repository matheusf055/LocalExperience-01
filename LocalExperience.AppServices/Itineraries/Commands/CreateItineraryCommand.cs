﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalExperience.AppServices.Itineraries.Commands
{
    public class CreateItineraryCommand
    {
        public Guid TripId { get; set; }
        public string Summary { get; set; }
    }
}
