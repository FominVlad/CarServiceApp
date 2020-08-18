using System.Collections.Generic;

namespace CarServiceApp.Models
{
    public class Role
    {
        /// <summary>
        /// User role unique id. (PK)
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// User role name.
        /// </summary>
        public string RoleName { get; set; }

        public List<User> Users { get; set; }
    }
}
