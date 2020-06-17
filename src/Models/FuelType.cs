﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceApp.Models
{
    public class FuelType
    {
        /// <summary>
        /// Fuel type unique id. (PK)
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Fuel type name.
        /// </summary>
        public string Type { get; set; }

        public List<Car> Cars { get; set; }
    }
}
