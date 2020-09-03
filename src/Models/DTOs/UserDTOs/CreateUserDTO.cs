using CarServiceApp.Helpers;
using System;
using System.ComponentModel.DataAnnotations;

namespace CarServiceApp.Models.DTOs
{
    public class CreateUserDTO
    {
        /// <summary>
        /// User first name.
        /// </summary>
        [Display(Name = "User name")]
        [Required(ErrorMessage = "Name can`t be empty!")]
        [StringLength(75, MinimumLength = 1, ErrorMessage =
            "Password length must be between 1 and 75 symbols!")]
        public string Name { get; set; }

        /// <summary>
        /// User surname.
        /// </summary>
        [Display(Name = "User surname")]
        [Required(ErrorMessage = "Surname can`t be empty!")]
        [StringLength(75, MinimumLength = 1, ErrorMessage =
            "Password length must be between 1 and 75 symbols!")]
        public string Surname { get; set; }

        /// <summary>
        /// User login.
        /// </summary>
        [Display(Name = "User login")]
        [Required(ErrorMessage = "Login can`t be empty!")]
        [StringLength(75, MinimumLength = 1, ErrorMessage =
            "Password length must be between 1 and 75 symbols!")]
        public string Login { get; set; }

        /// <summary>
        /// User password (hash).
        /// </summary>
        [Display(Name = "User password")]
        [Required(ErrorMessage = "Password can`t be empty!")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = 
            "Password length must be between 8 and 50 symbols!")]
        public string Password { get; set; }

        /// <summary>
        /// User role unique id.
        /// </summary>
        [Display(Name = "User role identifier")]
        [Required(ErrorMessage = "Role identifier can`t be empty!")]
        [Range(1, int.MaxValue, ErrorMessage = 
            "Invalid value! Please enter a number greater than 0!")]
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
