using PhotoryModels;
using System.Linq;

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