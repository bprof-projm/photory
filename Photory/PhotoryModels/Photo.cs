using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PhotoryModels
{
    public class Photo
    {
        [Key]
        public string PhotoID { get; set; }

        public string Path { get; set; }

        public string UserName { get; set; }

        public List<string> CommentIDs{ get; set; }

        public DateTime PostTime { get; set; }

        public string GroupId { get; set; }

        public virtual User User { get; set; }

        public virtual Group Group { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

    }
}
