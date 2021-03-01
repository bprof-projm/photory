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
        public void AcceptUser(User u);

        //DENY USER
        public void DenyUser(User u);



    }
}
