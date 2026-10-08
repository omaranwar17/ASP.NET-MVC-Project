using System.ComponentModel.DataAnnotations;

namespace App_User_10.ViewModels.Auth
{
    public class ForgetPasswordViewM
    {
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;
    }
}
