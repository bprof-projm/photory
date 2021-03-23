using PhotoryLogic.Interfaces;
using PhotoryModels;
using PhotoryRepository;
using PhotoryRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoryLogic.Classes
{
    public class GroupAdminLogic : IGroupAdminLogic
    {
        private IGroupAdminRepository groupadminRepo;
        public GroupAdminLogic(IGroupAdminRepository groupadminRepo)
        {
            this.groupadminRepo = groupadminRepo;
        }
        public void CreateGroupAdmin(User groupadmin)
        {

                //TODO: hashpw 
                this.groupadminRepo.Add(groupadmin);

        }

        public void DeleteGroupAdmin(string GroupAdminID)
        {
            
                this.groupadminRepo.Delete(GroupAdminID);
    
        }

        public IQueryable<User> GetAllGroupAdmin()
        {
            return this.groupadminRepo.GetAll();
        }

        public User GetGroupAdmin(string GroupAdminID)
        {
            return this.groupadminRepo.GetOne(GroupAdminID);
        }

        public void UpdateGroupAdmin(string GroupAdminID, User groupadmin)
        {

                this.groupadminRepo.Update(GroupAdminID, groupadmin);
  
        }

        public void AcceptUser(string userID, string GroupID)
        {
 
                this.groupadminRepo.AcceptUser(userID,GroupID);

        }
        public void DenyUser(string userID, string GroupID)
        {

                this.groupadminRepo.DenyUser(userID, GroupID);

        }
    }
}
