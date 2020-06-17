using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceApp.Models
{
    public class Car
    {
        /// <summary>
        /// Car VIN code. (PK)
        /// </summary>
        public string VIN { get; set; }

        /// <summary>
        /// Internal combustion engine.
        /// </summary>
        public float EngineVolume { get; set; }

        /// <summary>
        /// Fuel type unique id.
        /// </summary>
        public int FuelTypeId { get; set; }

        /// <summary>
        /// Car release date (from factory).
        /// </summary>
        public DateTime ReleaseDate { get; set; }

        /// <summary>
        /// Reference to car model unique id.
        /// </summary>
        public int CarModelId { get; set; }

        public List<CustomerCar> CustomerCars { get; set; }

        public FuelType FuelType { get; set; }

        public CarModel CarModel { get; set; }
    }
}
