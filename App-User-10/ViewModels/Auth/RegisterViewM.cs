using System.ComponentModel.DataAnnotations;

namespace App_User_10.ViewModels.Auth
{
    public class RegisterViewM
    {
        [Required(ErrorMessage = "Username is required")]
        [MaxLength(50, ErrorMessage = "Username must be less than 50 characters")]
        public string Username { get; set; } = null!;
        [Required(ErrorMessage = "Firstname is required")]
        [MaxLength(50, ErrorMessage = "Firstname must be less than 50 characters")]
        public string Firstname { get; set; } = null!;

        [Required(ErrorMessage = "Lastname is required")]
        [MaxLength(50, ErrorMessage = "Lastname must be less than 50 characters")]
        public string? Lastname { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
        public string Password { get; set; } = null!;
        [Required(ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }= null!;
        [Required(ErrorMessage = "You must agree to the terms and conditions")]
        public bool IsAgree { get; set; }
    }
}
