using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceApp.Models
{
    public class Customer
    {
        /// <summary>
        /// Client unique id. (PK)
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Customer first name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Customer surname.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Customer patronymic.
        /// </summary>
        public string Patronymic { get; set; }

        /// <summary>
        /// Customer birthday.
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// Customer passport number.
        /// </summary>
        public string PassportNumber { get; set; }

        public List<CustomerCar> CustomerCars { get; set; }

        public List<Contact> Contacts { get; set; }
    }
}
