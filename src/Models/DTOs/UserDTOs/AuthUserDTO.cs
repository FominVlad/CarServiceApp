using System.ComponentModel.DataAnnotations;

namespace CarServiceApp.Models.DTOs
{
    public class AuthUserDTO
    {
        /// <summary>
        /// User login.
        /// </summary>
        [Required(ErrorMessage = "Login can`t be null!")]
        [StringLength(75, MinimumLength = 1, ErrorMessage = 
            "Login length must be between 1 and 50 symbols!")]
        [Display(Name = "User login")]
        public string Login { get; set; }

        /// <summary>
        /// User password (hash).
        /// </summary>
        [Required(ErrorMessage = "Password can`t be null!")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = 
            "Password length must be between 8 and 50 symbols!")]
        [Display(Name = "User password")]
        public string Password { get; set; }
    }
}
