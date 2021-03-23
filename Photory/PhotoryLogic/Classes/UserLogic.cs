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
    public class UserLogic : IUserLogic
    {
        private IUserRepository userRepo;
        private IUserOfGroupRepository userofgrouprepo;
        public UserLogic(IUserRepository userRepo, IUserOfGroupRepository userofgrouprepo)
        {
            this.userRepo = userRepo;
            this.userofgrouprepo = userofgrouprepo;
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
                this.userRepo.RequestJoin(userID,GroupID);

        }
        public User GetUserFromGroup(string userID, string GroupID) 
        {
            var entity = (from x in userofgrouprepo.GetAll()
                          where x.UserName == userID && x.GroupName == GroupID
                          select x).FirstOrDefault();

            var userentity = userRepo.GetOne(entity.UserName);

            return userentity;
        }
    }
}
