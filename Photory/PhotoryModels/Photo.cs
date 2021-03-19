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

        public string Path { get; set; }

        public string UserName { get; set; }

        //public List<string> CommentIDs{ get; set; }

        public DateTime PostTime { get; set; }

        public string GroupId { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual User User { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual PhotoOfGroup Group { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<CommentOfPhoto> Comments { get; set; }

    }
}
