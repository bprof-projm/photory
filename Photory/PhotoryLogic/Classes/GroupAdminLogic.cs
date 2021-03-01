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
        public GroupAdminLogic(string connectionpassword)
        {
            this.groupadminRepo = new GroupAdminRepository(connectionpassword);
        }
        public bool CreateGroupAdmin(User groupadmin)
        {
            try
            {
                //TODO: hashpw 
                this.groupadminRepo.Add(groupadmin);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteGroupAdmin(string GroupAdminID)
        {
            try
            {
                this.groupadminRepo.Delete(GroupAdminID);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IQueryable<User> GetAllGroupAdmin()
        {
            return this.groupadminRepo.GetAll();
        }

        public User GetGroupAdmin(string GroupAdminID)
        {
            return this.groupadminRepo.GetOne(GroupAdminID);
        }

        public bool UpdateGroupAdmin(string GroupAdminID, User groupadmin)
        {
            try
            {
                this.groupadminRepo.Update(GroupAdminID, groupadmin);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool AcceptUser(string userID, string GroupID)
        {
            try
            {
                this.groupadminRepo.AcceptUser(userID,GroupID);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DenyUser(string userID, string GroupID)
        {
            try
            {
                this.groupadminRepo.DenyUser(userID, GroupID);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
