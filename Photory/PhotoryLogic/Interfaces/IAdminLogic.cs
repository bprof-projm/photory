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
        void CreateAdmin(User admin);
        void DeleteAdmin(string AdminID);
        void UpdateAdmin(string OldID, User user);
        IQueryable<User> GetAllUser();
        User GetAdmin(string AdminID);
    }
}
