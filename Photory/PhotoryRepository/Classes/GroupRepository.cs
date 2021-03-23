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
    public class GroupRepository : IGroupRepository
    {
        private PhotoryDbContext context = new PhotoryDbContext();

        public GroupRepository(PhotoryDbContext context)
        {
            this.context = context;
        }




        public void Add(Group entity)
        {
            this.context.Groups.Add(entity);
            SaveDatabase();
        }

        public void Delete(string id)
        {
            var entity = GetOne(id);

            this.context.Groups.Remove(entity);
            SaveDatabase();
        }

        public IQueryable<Group> GetAll()
        {
            return context.Groups;
        }

        public Group GetOne(string id)
        {
            var entity = (from x in context.Groups
                         where x.GroupName == id
                         select x).FirstOrDefault();


            return entity;
        }

        public void SaveDatabase()
        {
            this.context.SaveChanges();
        }

        public void Update(string oldid, Group entity)
        {
            throw new NotImplementedException();
        }
    }
}
