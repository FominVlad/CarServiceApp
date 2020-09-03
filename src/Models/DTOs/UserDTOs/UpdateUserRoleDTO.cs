using System;
using System.ComponentModel.DataAnnotations;

namespace CarServiceApp.Models.DTOs
{
    public class UpdateUserRoleDTO
    {
        /// <summary>
        /// Car model unique id. (PK)
        /// </summary>
        [Display(Name = "User unique identifier")]
        [Required(ErrorMessage = "User identifier can`t be empty!")]
        [Range(1, int.MaxValue, ErrorMessage =
            "Invalid value! Please enter a number greater than 0!")]
        public int Id { get; set; }

        /// <summary>
        /// User role unique id.
        /// </summary>
        [Display(Name = "User role identifier")]
        [Required(ErrorMessage = "Role identifier can`t be empty!")]
        [Range(1, int.MaxValue, ErrorMessage =
            "Invalid value! Please enter a number greater than 0!")]
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
