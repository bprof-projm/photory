using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoryModels
{
    class Photo
    {
        public string PhotoID { get; set; }

        public string Path { get; set; }

        public string UserName { get; set; }

        //public List<Comment> Comments{ get; set; }

        public DateTime PostTime { get; set; }

        public string GroupId { get; set; }

    }
}
