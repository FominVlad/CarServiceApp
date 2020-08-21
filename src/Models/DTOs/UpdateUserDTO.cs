using CarServiceApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceApp.Models.DTOs
{
    public class UpdateUserDTO
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
        /// User password (hash).
        /// </summary>
        public string Password { get; set; }

        public static explicit operator User(UpdateUserDTO updateUserDTO)
        {
            return new User
            {
                Id = updateUserDTO.Id,
                Name = updateUserDTO.Name,
                Surname = updateUserDTO.Surname,
                Login = string.IsNullOrEmpty(updateUserDTO.Password) ||
                    string.IsNullOrEmpty(updateUserDTO.Login) ? "" : updateUserDTO.Login,
                Password = string.IsNullOrEmpty(updateUserDTO.Password) || 
                    string.IsNullOrEmpty(updateUserDTO.Login) ? "" : 
                    PasswordManager.GetPassHash(updateUserDTO.Login, updateUserDTO.Password)
            };
        }
    }
}
