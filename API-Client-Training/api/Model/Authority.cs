using api.Model;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model
{
    [Table("AUTHORITY")]
    public class Authority
    {
        public string Account_NIK { get; set; }
        public int Role_Id { get; set; }
        [JsonIgnore]
        public virtual Account Account { get; set; }
        [JsonIgnore]
        public virtual Role Role { get; set; }
    }
}
