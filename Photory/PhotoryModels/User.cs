using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        public string UserName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Password { get; set; }

        public UserAccess UserAccess { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Group> Groups { get; set; }

    }
}
