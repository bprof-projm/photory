using PhotoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoryLogic.Interfaces
{
    public interface IGroupAdminLogic
    {
        bool CreateGroupAdmin(User groupadmin);
        bool DeleteGroupAdmin(string GroupAdminID);
        bool UpdateGroupAdmin(string GroupAdminID,User  groupadmin);
        IQueryable<User> GetAllGroupAdmin();
        User GetGroupAdmin(string GroupAdminID);
    }
}
