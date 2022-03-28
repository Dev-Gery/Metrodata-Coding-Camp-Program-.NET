using System.ComponentModel.DataAnnotations;

namespace API.Model.ViewModel
{
    public class LoginVM
    {
       [Required(ErrorMessage = "Please enter email")] public string Email { get; set; }
       [Required] public string Password { get; set; }
    }
}
