using PhotoryLogic.Interfaces;
using PhotoryModels;
using PhotoryRepository.Interfaces;
using System;
using System.IO;
using System.Linq;

namespace PhotoryLogic.Classes
{
    public class GroupAdminLogic : IGroupAdminLogic
    {
        private IGroupAdminRepository groupadminRepo;
        private IGroupRepository groupRepo;

        public GroupAdminLogic(IGroupAdminRepository groupadminRepo, IGroupRepository groupRepo)
        {
            this.groupadminRepo = groupadminRepo;
            this.groupRepo = groupRepo;
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
            this.groupadminRepo.AcceptUser(userID, GroupID);
        }

        public void DenyUser(string userID, string GroupID)
        {
            this.groupadminRepo.DenyUser(userID, GroupID);
        }

        public void SetGroupPicture(string fileName, string GroupID)
        {
            var fullpath = Path.Combine(Environment.CurrentDirectory + @"\Photos", fileName);
            if (File.Exists(fullpath) && groupRepo.GetOne(GroupID) != null)
            {
                var groupentity = groupRepo.GetOne(GroupID);
                FileInfo f = new FileInfo(fullpath);
                groupentity.PhotoData = File.ReadAllBytes(f.FullName);
                groupRepo.SaveDatabase();
                File.Delete(fullpath);
                //Photo p = new Photo();
                //p.PhotoID = Guid.NewGuid().ToString();
                //p.PhotoTitle = fileName;
                //p.GroupId = groupID;
                //p.UserID = userid;
                //var optimizer = new ImageOptimizer();
                //FileInfo f = new FileInfo(fullpath);
                //optimizer.Compress(f);
                //f.Refresh();
                //p.PhotoData = File.ReadAllBytes(f.FullName);
                //userRepo.AddPhoto(p);
                //File.Delete(fullpath);
                return;
            }
            throw new Exception("file was not found");
        }
    }
}