using PhotoryData;
using PhotoryModels;
using PhotoryRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoryRepository.Classes
{
    public class AdminRepository : IAdminRepository
    {
        private PhotoryDbContext context = new PhotoryDbContext();

        public AdminRepository(PhotoryDbContext context)
        {
            this.context = context;
        }

        public void Add(User entity)
        {
            entity.UserAccess = UserAccess.Admin;
            this.context.Users.Add(entity);
            SaveDatabase();
        }

        public void Delete(string id)
        {
            var entity = GetOne(id);

            this.context.Users.Remove(entity);
            SaveDatabase();
        }

        public IQueryable<User> GetAll()
        {
            var entity = from x in context.Users
                          where  x.UserAccess == UserAccess.Admin
                          select x;
            return entity;
        }

        public User GetOne(string id)
        {
            var entity = (from x in context.Users
                          where x.UserName == id && x.UserAccess == UserAccess.Admin
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


        public void AddMember(string userID, string GroupID)//Groupid,userid //public void AcceptUser(User u)
        {
            //var groupentity = (from x in context.Groups
            //                   where x.GroupName == GroupID
            //                   select x).FirstOrDefault();


            var groupentity = (from x in context.UserOfGroup
                               where x.UserName == userID && x.GroupName == GroupID
                               select x).FirstOrDefault();



            context.UserOfGroup.Add(groupentity);
            SaveDatabase();
        }

        public void CreateGroup(Group group)
        {
            this.context.Groups.Add(group);
            SaveDatabase();
        }
    }
}
