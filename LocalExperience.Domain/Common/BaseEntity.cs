﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalExperience.Domain.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; } 

        protected BaseEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}
