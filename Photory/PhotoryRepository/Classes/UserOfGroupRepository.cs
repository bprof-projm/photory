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
    public class UserOfGroupRepository : IUserOfGroupRepository
    {
        private PhotoryDbContext context = new PhotoryDbContext();

        public UserOfGroupRepository(PhotoryDbContext context)
        {
            this.context = context;
        }

        public void Add(UserOfGroup entity)
        {
            context.UserOfGroup.Add(entity);
            SaveDatabase();
        }

        public void Delete(string id)
        {
            var entity = GetOne(id);

            context.UserOfGroup.Remove(entity);
            SaveDatabase();
        }

        public IQueryable<UserOfGroup> GetAll()
        {
            return context.UserOfGroup.AsQueryable();
        }




        public UserOfGroup GetOne(string id)
        {
            var entity = (from x in context.UserOfGroup
                          where id == x.ID
                          select x).FirstOrDefault();


            return entity;
        }

        public void SaveDatabase()
        {
            this.context.SaveChanges();
        }

        public void Update(string oldid, UserOfGroup entity)
        {
            throw new NotImplementedException();
        }


        //NON-CRUD

        public IQueryable<UserOfGroup> GetAllPendingUser()
        {
            var users = from x in context.UserOfGroup
                        where x.IsPending == true
                        select x;
            return users;
        }

        public IQueryable<UserOfGroup> GetAllAcceptedUser()
        {
            var users = from x in context.UserOfGroup
                        where x.IsPending == false
                        select x;

            return users;
        }
    }
}
