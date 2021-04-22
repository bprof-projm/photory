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
        [Required]
        public string Email { get; set; }

        [Required]
        public string FullName { get; set; }
        
        [Key]
        public string UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
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
