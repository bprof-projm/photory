using PhotoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoryRepository.Interfaces
{
    public interface IGroupAdminRepository : IRepository<User>
    {
        //ACCEPT USER
        public void AcceptUser(string userID, string GroupID);

        //DENY USER
        public void DenyUser(string userID, string GroupID);



    }
}
