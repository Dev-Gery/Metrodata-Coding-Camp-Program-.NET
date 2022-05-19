using api.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace API.Model
{
    [Table("ACCOUNT")]
    public class Account
    {
        [Key]
        public string NIK { get; set; }
        [Required]
        public string Password { get; set; }
        public string OTP { get; set; }
        public DateTime ExpiredToken { get; set; }
        public bool IsUsed { get; set; }
        [JsonIgnore]
        public virtual Employee Employee { get; set; }
        [JsonIgnore]
        public virtual Profiling Profiling { get; set; }
        public virtual ICollection<Authority> Authorities { get; set; }

    }
}
