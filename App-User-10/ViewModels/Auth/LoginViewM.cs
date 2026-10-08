using System.ComponentModel.DataAnnotations;

namespace App_User_10.ViewModels.Auth
{
    public class LoginViewM
    {
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;
     
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
        public string Password { get; set; } = null!;
        [Required(ErrorMessage = "You must agree to the terms and conditions")]
        public bool RememberMe { get; set; }
    }
}
