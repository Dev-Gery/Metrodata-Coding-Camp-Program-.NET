using api.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model
{
    [Table("UNIVERSITY")]
    public class University
    {
        [Key] public int Id { get; set; }
        [Required] public string Name { get; set; }
        public virtual ICollection<Education> Educations { get; set; }
    }
}
