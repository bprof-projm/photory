using System;
using System.IO;
using System.Linq;
using PhotoryData;
using PhotoryModels;
using PhotoryRepository.Interfaces;

namespace PhotoryRepository
{
    public class UserRepository : IUserRepository
    {
        private PhotoryDbContext context = new PhotoryDbContext();



        public UserRepository(PhotoryDbContext context)
        {
            this.context = context;
        }

        //CRUD

        public void Add(User entity)
        {
            entity.UserId = Guid.NewGuid().ToString();
            entity.UserAccess = UserAccess.RegularUser;
            this.context.MyUsers.Add(entity);
            SaveDatabase();
        }

        public void Delete(string id)
        {
            var entity = GetOne(id);
            this.context.MyUsers.Remove(entity);
            SaveDatabase();
        }


        public void Update(string oldid, User entity)
        {
            var olduser = GetOne(oldid);

            olduser.BirthDate = entity.BirthDate;
            olduser.Email = entity.Email;
            olduser.UserAccess = entity.UserAccess;
            SaveDatabase();
        }

        public IQueryable<User> GetAll()
        {
            var q1 = from x in context.MyUsers
                      where x.UserAccess == UserAccess.RegularUser
                      select x;

            return q1;
        }

        public User GetOne(string id)
        {
            var q1 = (from x in context.MyUsers
                      where id == x.UserId                  //&& x.UserAccess == UserAccess.RegularUser
                      select x).FirstOrDefault();

            if (q1.UserAccess == UserAccess.RegularUser)
            {
                return q1;
            }
            return null;
           
        }


        public void SaveDatabase()
        {
            this.context.SaveChanges();
        }



        public void AddComment(Comment m)
        {
            this.context.Comments.Add(m);
            SaveDatabase();
        }

        public void AddPhoto(Photo p)
        {
            this.context.Photos.Add(p);
            SaveDatabase();
        }


        public IQueryable<Comment> GetAllCommentsFromPhoto(string photoID)
        {

            var comments = from x in context.Comments
                           where x.PhotoID == photoID
                           select x;


            return comments;
        }


        public void DeleteComment(string CommentID)
        {
            var entity = (from x in context.Comments
                          where x.CommentID == CommentID
                          select x).FirstOrDefault();

            this.context.Comments.Remove(entity);
            SaveDatabase();
        }

        public void DeletePhoto(string PhotoID)
        {
            var entity = (from x in context.Photos
                          where x.PhotoID == PhotoID
                          select x).FirstOrDefault();

            this.context.Photos.Remove(entity);
            SaveDatabase();
        }



        public void RequestJoin(string userID, string GroupID)
        {

            var entity = (from x in context.Groups
                          where x.GroupName == GroupID
                          select x).FirstOrDefault();

            UserOfGroup uog = new UserOfGroup();

            uog.ID = userID;
            uog.IsPending = true;
            uog.GroupName = GroupID;


            SaveDatabase();
        }


    }
}