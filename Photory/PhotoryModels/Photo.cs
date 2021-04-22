using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace PhotoryModels
{
    public class Photo
    {
        [Key]
        public string PhotoID { get; set; }

        public string PhotoTitle { get; set; }
        public byte[] PhotoData { get; set; }

        [Required]
        public string UserID { get; set; }

        //public List<string> CommentIDs{ get; set; }

        public DateTime PostTime { get; set; }

        [Required]
        public string GroupId { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual User User { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Group Group { get; set; }


        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Comment> Comments { get; set; }

    }
}
