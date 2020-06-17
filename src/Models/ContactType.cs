using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceApp.Models
{
    public class ContactType
    {
        /// <summary>
        /// Contact type unique id. (PK)
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Contact type.
        /// </summary>
        public string Type { get; set; }

        public List<Contact> Contacts { get; set; }
    }
}
