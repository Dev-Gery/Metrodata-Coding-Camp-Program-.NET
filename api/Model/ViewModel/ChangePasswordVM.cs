using System.ComponentModel.DataAnnotations;

namespace API.Model.ViewModel
{
    public class ChangePasswordVM
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string OTP { get; set; }
        [Required]
        public string NewPassword { get; set; }
        [Required]
        public string ConfirmNewPassword { get; set; }
    }
}
