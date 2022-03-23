using api.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model
{
    [Table("ACCOUNT")]
    public class Account
    {
        [Key, MaxLength(15)] public string NIK { get; set; }
        [Required] public string Password { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Profiling Profiling { get; set; }
    }
}
