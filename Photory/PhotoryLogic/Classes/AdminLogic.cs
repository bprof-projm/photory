using PhotoryLogic.Interfaces;
using PhotoryModels;
using PhotoryRepository.Interfaces;
using PhotoryRepository.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PhotoryLogic.Classes
{
    public class AdminLogic : IAdminLogic
    {
        private IAdminRepository adminRepo;
        private IUserRepository userrepo;
        private IGroupRepository grouprepo;
        private IUserOfGroupRepository userofgrouprepo;
        public AdminLogic(IAdminRepository adminRepo, IGroupRepository grouprepo, IUserRepository userrepo, IUserOfGroupRepository userofgrouprepo)
        {
            this.adminRepo = adminRepo;
            this.grouprepo = grouprepo;
            this.userrepo = userrepo;
            this.userofgrouprepo = userofgrouprepo;
        }
        public void CreateAdmin(User admin)
        {
 
                //TODO: hashpw 
          this.adminRepo.Add(admin);
 
        }

        public void DeleteAdmin(string AdminID)
        {

         this.adminRepo.Delete(AdminID);
 
        }

        public User GetAdmin(string AdminID)
        {
            return this.adminRepo.GetOne(AdminID);
        }

        public IQueryable<User> GetAllUser()
        {
            return this.adminRepo.GetAll();
        }

        public void UpdateAdmin(string OldID, User user)
        {

          this.adminRepo.Update(OldID, user);

        }
        public void AddMember(string userID, string GroupID)
        {

            var userentity = userrepo.GetOne(userID);
            var groupentity = grouprepo.GetOne(GroupID);

            UserOfGroup uog = new UserOfGroup();
            uog.Group = groupentity;
            uog.GroupName = groupentity.GroupName;
            uog.User = userentity;
            uog.UserName = userentity.UserId;
            uog.ID = Guid.NewGuid().ToString();
            uog.IsPending = false;


            this.userofgrouprepo.Add(uog);

            //this.adminRepo.AddMember(userID,GroupID);
 
        }


     
        public void CreateGroup(Group group)
        {
          
           this.adminRepo.CreateGroup(group);

        }


        public void DeleteGroup(string GroupID)
        {

            this.grouprepo.Delete(GroupID);

        }
    }
}
