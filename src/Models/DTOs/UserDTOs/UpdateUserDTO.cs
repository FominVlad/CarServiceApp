using CarServiceApp.ValidationAttributes;
using CarServiceApp.Helpers;
using System.ComponentModel.DataAnnotations;

namespace CarServiceApp.Models.DTOs
{
    [UpdateLoginPassword]
    public class UpdateUserDTO
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
        /// User first name.
        /// </summary>
        [Display(Name = "User name")]
        [NullOrLimitLengthString(1, 75, ErrorMessage = 
            "User name must be null or length must be between 1 and 75 symbols!")]
        public string Name { get; set; }

        /// <summary>
        /// User surname.
        /// </summary>
        [NullOrLimitLengthString(1, 75, ErrorMessage =
            "User surname must be null or length must be between 1 and 75 symbols!")]
        [Display(Name = "User surname")]
        public string Surname { get; set; }

        /// <summary>
        /// User login.
        /// </summary>
        [NullOrLimitLengthString(1, 75, ErrorMessage =
            "User login must be null or length must be between 1 and 75 symbols!")]
        [Display(Name = "User login")]
        public string Login { get; set; }

        /// <summary>
        /// User password (hash).
        /// </summary>
        [NullOrLimitLengthString(8, 50, ErrorMessage =
            "User password must be null or length must be between 8 and 50 symbols!")]
        [Display(Name = "User password")]
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
