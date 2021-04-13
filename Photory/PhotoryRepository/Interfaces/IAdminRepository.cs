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
        public void CreateGroup(Group group);//CreateGroup();

        //ADD-MEMBER TO GROUP
        public void AddMember(string userID, string GroupID);

       

       

    }
}
