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
        void CreateGroupAdmin(User groupadmin);
        void DeleteGroupAdmin(string GroupAdminID);
        void UpdateGroupAdmin(string GroupAdminID,User  groupadmin);
        IQueryable<User> GetAllGroupAdmin();
        User GetGroupAdmin(string GroupAdminID);
    }
}
