﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceApp.Models
{
    public class CustomerCar
    {
        /// <summary>
        /// Row unique id. (PK)
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Reference to customer id.
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Reference to car id.
        /// </summary>
        public string CarId { get; set; }

        /// <summary>
        /// Relevance of recording.
        /// </summary>
        public bool Actual { get; set; } 

        public Customer Customer { get; set; }

        public Car Car { get; set; }
    }
}
