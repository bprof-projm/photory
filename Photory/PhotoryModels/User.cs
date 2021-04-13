using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PhotoryModels
{

    public enum UserAccess 
    {
        RegularUser,GroupAdmin,Admin
    }

    public class User
    {
        public string Email { get; set; }

        public string FullName { get; set; }
        
        [Key]
        public string UserId { get; set; }


        public string UserName { get; set; }

        public DateTime BirthDate { get; set; }

        public UserAccess UserAccess { get; set; }


        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Comment> Comments { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<UserOfGroup> UserGroups { get; set; }

    }
}
