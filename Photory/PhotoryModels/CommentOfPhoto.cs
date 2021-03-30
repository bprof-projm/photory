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
    public class CommentOfPhoto
    {


       [Key]
        public string PhotoID { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Photo Photo { get; set; }

        public string CommentID { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Comment Comment { get; set; }

    }
}
