using System.ComponentModel.DataAnnotations;

namespace App_User_10.ViewModels.Auth
{
    public class ResetPasswordViewM
    {
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
        public string NewPassword { get; set; } = null!;
        [Required(ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.Password)]
        [Compare(nameof(NewPassword), ErrorMessage = "Passwords do not match")]
        public string NewConfirmPassword { get; set; } = null!;
    }
}
