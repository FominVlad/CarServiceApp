using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceApp.Models
{
    public class Car
    {
        /// <summary>
        /// Car VIN code.
        /// </summary>
        public string VIN { get; set; }

        /// <summary>
        /// Car brand name.
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Car model name.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Internal combustion engine.
        /// </summary>
        public decimal EngineVolume { get; set; }

        /// <summary>
        /// Fuel type unique id.
        /// </summary>
        public int FuelTypeId { get; set; }
    }
}
