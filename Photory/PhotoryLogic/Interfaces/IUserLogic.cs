using PhotoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoryLogic.Interfaces
{
    public interface IUserLogic
    {

        bool CreateUser(User user);
        bool DeleteUser(string UserID);
        bool UpdateUser(string OldID , User user);
        IQueryable<User> GetAllUser();
        User GetUser(string UserID);
        //?Should we have more in here 
    }
}
