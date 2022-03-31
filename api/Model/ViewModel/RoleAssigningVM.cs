using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Model.ViewModel
{
    public class RoleAssigningVM
    {
        [Required]
        public string NIK { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string Role_Ids { get; set; }
        public string Role_Names { get; set; } 
    }
}
