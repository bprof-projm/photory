using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PhotoryModels
{
    public class UserOfGroup
    {
        [Key]
        public string UserId { get; set; }

        public string UserName { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual User User { get; set; }


        public bool IsPending { get; set; }


        
        public string GroupName { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Group Group { get; set; }

    }
}
