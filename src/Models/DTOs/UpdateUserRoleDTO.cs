using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceApp.Models.DTOs
{
    public class UpdateUserRoleDTO
    {
        /// <summary>
        /// Car model unique id. (PK)
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// User role unique id.
        /// </summary>
        public int RoleId { get; set; }

        public static explicit operator User(UpdateUserRoleDTO updateUserRoleDTO)
        {
            return new User
            {
                Id = updateUserRoleDTO.Id,
                RoleId = updateUserRoleDTO.RoleId
            };
        }
    }
}
