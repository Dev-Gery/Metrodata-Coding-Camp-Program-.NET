using api.Model;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace API.Model
{
    [Table("PROFILING")]
    public class Profiling
    {
        [Key] public string NIK { get; set; }
        public int Education_Id { get; set; }
        public virtual Education Education { get; set; }
        [JsonIgnore]
        public virtual Account Account { get; set; }
    }
}
