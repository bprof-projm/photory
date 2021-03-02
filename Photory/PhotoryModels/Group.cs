using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PhotoryModels
{
    public class Group
    {
        [Key]
        public string GroupName { get; set; }

        public string GroupAdminID { get; set; }

        public int Age { get; set; }

        public List<string> PendingUserIDList { get; set; }

        public List<string> PhotoIDList { get; set; }

        public List<string> UsersID { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }
    }
}
