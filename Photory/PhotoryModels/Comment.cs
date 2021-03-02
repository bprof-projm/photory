using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PhotoryModels
{
    public class Comment
    {
        [Key]
        public string CommentID { get; set; }


        public string UserID { get; set; }

        public string CommentContent { get; set; }

        public string PhotoID { get; set; }

        public virtual Photo Photo { get; set; }

    }
}
