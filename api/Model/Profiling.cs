using api.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model
{
    [Table("PROFILING")]
    public class Profiling
    {
        [Key, MaxLength(15)] public string NIK { get; set; }
        public Education Education { get; set; }
        public virtual Account Account { get; set; }
    }
}
