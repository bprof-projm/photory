using PhotoryLogic.Interfaces;
using PhotoryModels;
using PhotoryRepository.Interfaces;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.IO;
using System.Linq;

namespace PhotoryLogic.Classes
{
    public class UserLogic : IUserLogic
    {
        private IUserRepository userRepo;
        private IUserOfGroupRepository userofgrouprepo;
        private IGroupRepository groupRepo;
        private IPhotoRepository photorepo;

        public UserLogic(IUserRepository userRepo, IUserOfGroupRepository userofgrouprepo, IGroupRepository groupRepo, IPhotoRepository photorepo)
        {
            this.userRepo = userRepo;
            this.userofgrouprepo = userofgrouprepo;
            this.groupRepo = groupRepo;
            this.photorepo = photorepo;
        }

        public void CreateUser(User user)
        {
            //TODO: hashpw
            this.userRepo.Add(user);
        }

        public void DeleteUser(string UserID)
        {
            this.userRepo.Delete(UserID);
        }

        public IQueryable<User> GetAllUser()
        {
            return this.userRepo.GetAll();
        }

        public User GetUser(string UserID)
        {
            return this.userRepo.GetOne(UserID);
        }

        public void UpdateUser(string OldID, User user)
        {
            this.userRepo.Update(OldID, user);
        }

        public void AddComment(Comment m)
        {
            m.CommentID = Guid.NewGuid().ToString();
            this.userRepo.AddComment(m);
        }

        public void DeleteComment(string CommentID)
        {
            this.userRepo.DeleteComment(CommentID);
        }

        public IQueryable<Comment> GetAllCommentsFromPhoto(string PhotoID)
        {
            return this.userRepo.GetAllCommentsFromPhoto(PhotoID);
        }

        public void AddPhoto(Photo p)
        {
            this.userRepo.AddPhoto(p);
        }

        public void DeletePhoto(string PhotoID)
        {
            this.userRepo.DeletePhoto(PhotoID);
        }

        public void RequestJoin(string userID, string GroupID)
        {
            var user = userRepo.GetOne(userID);
            var group = groupRepo.GetOne(GroupID);

            if ((DateTime.Now - user.BirthDate).Days > group.Age * 365)
            {
                this.userRepo.RequestJoin(userID, GroupID);
            }
            else
            {
                throw new ArgumentException("Age restrection validation error");
            }
        }

        public void LeaveGroup(string userID, string GroupID)
        {
            this.userRepo.LeaveGroup(userID, GroupID);
        }

        public User GetUserFromGroup(string userID, string GroupID)
        {
            var entity = (from x in userofgrouprepo.GetAll()
                          where x.UserName == userID && x.GroupName == GroupID
                          select x).FirstOrDefault();

            var userentity = userRepo.GetOne(entity.UserName);

            return userentity;
        }

        public void UploadtoData(string fileName, string groupID, string userid)
        {
            var user = userofgrouprepo.GetOne(userid);
            if (user.IsPending == false)
            {



                var fullpath = Path.Combine(Environment.CurrentDirectory + @"\Photos", fileName);
                if (File.Exists(fullpath) && groupRepo.GetOne(groupID) != null)
                {
                    var image = Image.Load(fullpath);

                    Photo p1 = new Photo();
                    p1.PhotoID = Guid.NewGuid().ToString();
                    p1.PhotoTitle = fileName;
                    p1.GroupId = groupID;
                    p1.IsRescaled = true;
                    p1.ConnectionId = Guid.NewGuid().ToString();
                    p1.UserID = userid;

                    Photo p2 = new Photo();
                    p2.PhotoID = Guid.NewGuid().ToString();
                    p2.PhotoTitle = "original_" + fileName;
                    p2.GroupId = groupID;
                    p2.ConnectionId = p1.ConnectionId;
                    p2.UserID = userid;
                    p2.IsRescaled = false;
                    p2.Height = image.Height;
                    p2.Width = image.Width;

                    var originaltmppath = Path.Combine(Environment.CurrentDirectory + @"\Photos", "Data_" + p2.PhotoTitle);
                    image.Save(originaltmppath);
                    FileInfo ff = new FileInfo(originaltmppath);
                    ff.Refresh();
                    p2.PhotoData = File.ReadAllBytes(ff.FullName);

                    image.Mutate(x => x.Resize(200, 200));

                    var tmppath = Path.Combine(Environment.CurrentDirectory + @"\Photos", "Data_" + fileName);
                    image.Save(tmppath);
                    FileInfo f = new FileInfo(tmppath);
                    f.Refresh();
                    p1.PhotoData = File.ReadAllBytes(f.FullName);

                    //var optimizer = new ImageOptimizer();
                    //FileInfo f = new FileInfo();
                    //optimizer.Compress(f);
                    //f.Refresh();
                    //p.PhotoData = File.ReadAllBytes(f.FullName);

                    p1.Height = image.Height;
                    p1.Width = image.Width;
                    userRepo.AddPhoto(p1);
                    userRepo.AddPhoto(p2);
                    File.Delete(tmppath);
                    File.Delete(fullpath);
                    File.Delete(originaltmppath);
                    return;
                }
                throw new Exception("file was not found");
            }
            else
            {
                throw new ArgumentException("You are not a member");
            }
        }

        public void GetOnePhoto(string PhotoID)
        {
            this.photorepo.GetOnePhoto(PhotoID);
        }

        public void GetOneRescaledPhoto(string PhotoID)
        {
            this.photorepo.GetOneRescaledPhoto(PhotoID);
        }
    }
}