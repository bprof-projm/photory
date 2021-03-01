using PhotoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoryRepository.Interfaces
{
    public interface IAdminRepository :IRepository<User>
    {

        //CREATE GROUP
        public void CreateGroup();

        //ADD-MEMBER TO GROUP
        public void AddMember(User u,string GroupID);

       

    }
}
