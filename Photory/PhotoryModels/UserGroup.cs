using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoryModels
{
    public class UserGroup
    {
        public string UserName { get; set; }
        public virtual User User { get; set; }

        public string GroupName { get; set; }

        public virtual Group Group { get; set; }




    }
}
