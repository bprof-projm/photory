using PhotoryModels;
using System.Linq;

namespace PhotoryLogic.Interfaces
{
    public interface IUserLogic
    {
        void CreateUser(User user);

        void DeleteUser(string UserID);

        void UpdateUser(string OldID, User user);

        IQueryable<User> GetAllUser();

        User GetUser(string UserID);

        //?Should we have more in here
    }
}