using api.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Model
{
    [Table("EDUCATION")]
    public class Education
    {
        [Key] public int Id { get; set; }
        [Required] public string Degree { get; set; }
        [Required] public string GPA { get; set; }
        public int University_Id { get; set; }
        [JsonIgnore]
        public virtual ICollection<Profiling> Profilings { get; set; }
        [JsonIgnore]
        public virtual University University { get; set; }
    }
}
