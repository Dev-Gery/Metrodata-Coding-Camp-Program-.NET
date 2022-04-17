using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace API.Model.ViewModel
{
    public class LoginVM
    {
       [Key][Required(ErrorMessage = "Please enter email")] public string Email { get; set; }
       [Required] public string Password { get; set; }
        public string JWT { get; set; }
    }
}
