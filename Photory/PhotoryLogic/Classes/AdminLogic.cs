using PhotoryLogic.Interfaces;
using PhotoryModels;
using PhotoryRepository.Interfaces;
using PhotoryRepository.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoryLogic.Classes
{
    public class AdminLogic : IAdminLogic
    {
        public IAdminRepository adminRepo;
        public AdminLogic(string connectionpassword)
        {
            this.adminRepo = new AdminRepository(connectionpassword);
        }
        public bool CreateAdmin(User admin)
        {
            try
            {
                //TODO: hashpw 
                this.adminRepo.Add(admin);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteAdmin(string AdminID)
        {
            try
            {
                this.adminRepo.Delete(AdminID);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public User GetAdmin(string AdminID)
        {
            return this.adminRepo.GetOne(AdminID);
        }

        public IQueryable<User> GetAllUser()
        {
            return this.adminRepo.GetAll();
        }

        public bool UpdateAdmin(string OldID, User user)
        {
            try
            {
                this.adminRepo.Update(OldID, user);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool AddMember(string userID, string GroupID)
        {
            try
            {
                this.adminRepo.AddMember(userID,GroupID);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool CreateGroup(Group group)
        {
            try
            {
                this.adminRepo.CreateGroup(group);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
