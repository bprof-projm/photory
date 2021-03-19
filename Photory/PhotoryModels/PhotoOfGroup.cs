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
    public class PhotoOfGroup
    {
        [Key]
        public string PhotoID { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Photo Photo { get; set; }

        public string GroupName { get; set; }


        [NotMapped]
        [JsonIgnore]
        public virtual Group Group { get; set; }

    }
}
