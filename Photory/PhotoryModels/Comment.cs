using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace PhotoryModels
{
    public class Comment
    {
        [Key]
        public string CommentID { get; set; }


        public string UserId { get; set; }

        public string CommentContent { get; set; }

        public string PhotoID { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Photo Photo { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual User User { get; set; }

    }
}
