using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace PhotoryModels
{
    public class Group
    {
        [Key]
        public string GroupName { get; set; }

        [Unique]
        [System.ComponentModel.DataAnnotations.Required]
        public string GroupAdminID { get; set; }

        [MaxLength(40)]
        public string Description { get; set; }

        [JsonIgnore]
        public byte[] PhotoData { get; set; }


        public int Age { get; set; }

        //public List<string> PendingUserIDList { get; set; }

        //public List<string> PhotoIDList { get; set; }

        //public List<string> UsersID { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<UserOfGroup> UserGroups { get; set; }


        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Photo>  Photos { get; set; }


    }
}
