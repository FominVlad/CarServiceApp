using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceApp.Models
{
    public class CarModel
    {
        /// <summary>
        /// Car model unique id. (PK)
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Car brand name.
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Car model name.
        /// </summary>
        public string Model { get; set; }

        public List<Car> Cars { get; set; }
    }
}
