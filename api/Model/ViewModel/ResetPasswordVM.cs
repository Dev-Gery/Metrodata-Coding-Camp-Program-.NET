using System.ComponentModel.DataAnnotations;

namespace API.Model.ViewModel
{
    public class ResetPasswordVM
    {
        [Required,EmailAddress]
        public string Email { get; set; }
    }
}
