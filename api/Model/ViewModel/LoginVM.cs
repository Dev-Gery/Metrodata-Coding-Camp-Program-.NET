using System.ComponentModel.DataAnnotations;

namespace API.Model.ViewModel
{
    public class LoginVM
    {
       [Required] public string Email { get; set; }
       [Required] public string Password { get; set; }
    }
}
