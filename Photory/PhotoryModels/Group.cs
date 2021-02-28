using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoryModels
{
    public class Group
    {

        public string GroupName { get; set; }

        public string GroupAdminID { get; set; }

        public int Age { get; set; }

        public List<string> PendingUserIDList { get; set; }

        public List<string> PhotoIDList { get; set; }

        public List<string> UsersID { get; set; }


    }
}
