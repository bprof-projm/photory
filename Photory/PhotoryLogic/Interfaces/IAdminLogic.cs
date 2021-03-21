using PhotoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoryLogic.Interfaces
{
    public interface IAdminLogic
    {
        bool CreateAdmin(User admin);
        bool DeleteAdmin(string AdminID);
        bool UpdateAdmin(string OldID, User user);
        IQueryable<User> GetAllUser();
        User GetAdmin(string AdminID);
    }
}
