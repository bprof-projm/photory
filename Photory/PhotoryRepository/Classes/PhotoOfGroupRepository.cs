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
    public class PhotoOfGroupRepository : IPhotoOfGroupRepository
    {

        PhotoryDbContext context = new PhotoryDbContext();

        public PhotoOfGroupRepository(PhotoryDbContext context)
        {
            this.context = context;
        }

        public void Add(PhotoOfGroup entity)
        {
            context.PhotoOfGroup.Add(entity);
            SaveDatabase();
        }

        public void Delete(string id)
        {
            var entity = GetOne(id);

            context.PhotoOfGroup.Remove(entity);
            SaveDatabase();
        }

        public IQueryable<PhotoOfGroup> GetAll()
        {
            return context.PhotoOfGroup;
        }

        public PhotoOfGroup GetOne(string id)
        {
            var entity = (from x in context.PhotoOfGroup
                          where x.PhotoID == id
                          select x).FirstOrDefault();


            return entity;
        }
        public Photo GetOnePhoto(string id)
        {
            var entity = (from x in context.Photos
                          where x.PhotoID == id
                          select x).FirstOrDefault();
            return entity;
        }

        public void SaveDatabase()
        {
            this.context.SaveChanges();
        }

        public void Update(string oldid, PhotoOfGroup entity)
        {
            throw new NotImplementedException();
        }
    }
}
