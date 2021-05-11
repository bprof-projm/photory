using PhotoryModels;
using System.Linq;

namespace PhotoryLogic.Interfaces
{
    public interface IGroupAdminLogic
    {
        void CreateGroupAdmin(User groupadmin);

        void DeleteGroupAdmin(string GroupAdminID);

        void UpdateGroupAdmin(string GroupAdminID, User groupadmin);

        IQueryable<User> GetAllGroupAdmin();

        User GetGroupAdmin(string GroupAdminID);
    }
}