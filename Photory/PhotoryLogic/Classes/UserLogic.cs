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
        public UserLogic(IUserRepository userRepo)
        {
            this.userRepo = userRepo;
        }
        public bool CreateUser(User user)
        {
            try
            {
                //TODO: hashpw 
                this.userRepo.Add(user);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteUser(string UserID)
        {
            try
            {
                this.userRepo.Delete(UserID);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IQueryable<User> GetAllUser()
        {
            return this.userRepo.GetAll();
        }

        public User GetUser(string UserID)
        {
            return this.userRepo.GetOne(UserID);
        }

        public bool UpdateUser(string OldID, User user)
        {
            try
            {
                this.userRepo.Update(OldID, user);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool AddComment(Comment m)
        {
            try
            {
                this.userRepo.AddComment(m);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        public bool DeleteComment(string CommentID)
        {
            try
            {
                this.userRepo.DeleteComment(CommentID);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool AddPhoto(Photo p)
        {
            try
            {
                this.userRepo.AddPhoto(p);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeletePhoto(string PhotoID)
        {
            try
            {
                this.userRepo.DeletePhoto(PhotoID);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool RequestJoin(string userID, string GroupID)
        {
            try
            {
                this.userRepo.RequestJoin(userID,GroupID);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
