using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceApp.Models
{
    public class Contact
    {
        /// <summary>
        /// Contact unique id. (PK)
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Reference to customer unique id.
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Reference to contact type unique id.
        /// </summary>
        public int ContactTypeId { get; set; }

        /// <summary>
        /// Contact value.
        /// </summary>
        public string ContactValue { get; set; }

        /// <summary>
        /// Relevance of recording.
        /// </summary>
        public bool Actual { get; set; }

        public Customer Customer { get; set; }

        public ContactType ContactType { get; set; }
    }
}
