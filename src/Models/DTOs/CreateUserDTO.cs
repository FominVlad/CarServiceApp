using CarServiceApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceApp.Models.DTOs
{
    public class CreateUserDTO
    {
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
        /// User password (hash).
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// User role unique id.
        /// </summary>
        public int RoleId { get; set; }

        public static explicit operator User(CreateUserDTO createUserDTO)
        {
            return new User
            {
                Name = createUserDTO.Name,
                Surname = createUserDTO.Surname,
                Login = createUserDTO.Login,
                Password = PasswordManager.GetPassHash(createUserDTO.Login, 
                    createUserDTO.Password),
                RoleId = createUserDTO.RoleId
            };
        }
    }
}
