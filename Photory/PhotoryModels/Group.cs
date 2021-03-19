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

        public string GroupAdminID { get; set; }

        public int Age { get; set; }

        //public List<string> PendingUserIDList { get; set; }

        //public List<string> PhotoIDList { get; set; }

        //public List<string> UsersID { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<UserOfGroup> UserGroups { get; set; }


        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<PhotoOfGroup> Photos { get; set; }
    }
}
