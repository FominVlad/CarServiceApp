using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceApp.Models.DTOs
{
    public class GetUserDTO
    {
        /// <summary>
        /// Car model unique id. (PK)
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// User first name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// User surname.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// User login.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// User role unique id.
        /// </summary>
        public int RoleId { get; set; }

        public static explicit operator GetUserDTO(User user)
        {
            return new GetUserDTO()
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Login = user.Login
            };
        }
    }
}
