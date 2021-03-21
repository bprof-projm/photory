using PhotoryData;
using PhotoryModels;
using PhotoryRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoryRepository
{
    public class GroupAdminRepository : IGroupAdminRepository
    {
        private PhotoryDbContext context = new PhotoryDbContext();

        public GroupAdminRepository(PhotoryDbContext context)
        {
            this.context = context;
        }



        public void Add(User entity)
        {
            //Todo nem biztos hogy jó ez így
            entity.UserAccess = UserAccess.GroupAdmin;
            this.context.Users.Add(entity);
            SaveDatabase();

        }

        public void Delete(string id)
        {
            var entity = GetOne(id);

            this.context.Users.Remove(entity);

        }



        public IQueryable<User> GetAll()
        {
            var groupadmins = from x in context.Users
                              where x.UserAccess == UserAccess.GroupAdmin
                              select x;

            return groupadmins;
        }

        public User GetOne(string id)
        {
            var entity = (from x in context.Users
                          where x.UserName == id && x.UserAccess == UserAccess.GroupAdmin
                          select x).FirstOrDefault();

            return entity;
        }

        public void SaveDatabase()
        {
            this.context.SaveChanges();
        }



        public void Update(string oldid, User entity)
        {
            var olduser = GetOne(oldid);

            olduser.BirthDate = entity.BirthDate;
            olduser.Email = entity.Email;
            olduser.UserAccess = entity.UserAccess;
            olduser.Password = entity.Password;
            SaveDatabase();
        }

        public void AcceptUser(string userID, string GroupID)//Groupid,userid //public void AcceptUser(User u)
        {
            //var groupentity = (from x in context.Groups
            //                  where x.GroupName == GroupID
            //                  select x).FirstOrDefault();

            var entity = (from x in context.UserOfGroup
                          where x.GroupName == userID
                          select x).FirstOrDefault();

            entity.IsPending = false;

            //groupentity.PendingUserIDList.Remove(userID);
            //groupentity.UsersID.Add(userID);
            SaveDatabase();
        }

        public void DenyUser(string userID, string GroupID) //public void DenyUser(User u)
        {
            //var groupentity = (from x in context.Groups
            //                   where x.GroupName == GroupID
            //                   select x).FirstOrDefault();

            //groupentity.PendingUserIDList.Remove(userID);


            var entity = (from x in context.UserOfGroup
                          where x.GroupName == userID
                          select x).FirstOrDefault();

            context.UserOfGroup.Remove(entity);

            SaveDatabase();
        }
    }
}
