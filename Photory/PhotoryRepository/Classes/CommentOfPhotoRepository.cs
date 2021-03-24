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
    public class CommentOfPhotoRepository : ICommentOfPhotoRepository
    {
        PhotoryDbContext context = new PhotoryDbContext();

        public CommentOfPhotoRepository(PhotoryDbContext context)
        {
            this.context = context;
        }


        public void Add(CommentOfPhoto entity)
        {
            context.CommentOfPhoto.Add(entity);
            SaveDatabase();
        }

        public void Delete(string id)
        {
            var entity = GetOne(id);

            context.CommentOfPhoto.Remove(entity);

            SaveDatabase();
        }

        public IQueryable<CommentOfPhoto> GetAll()
        {
            return context.CommentOfPhoto;
        }

        public CommentOfPhoto GetOne(string id)
        {
            var entity = (from x in context.CommentOfPhoto
                          where x.CommentID == id
                          select x).FirstOrDefault();


            return entity;
        }

        public void SaveDatabase()
        {
            this.context.SaveChanges();
        }

        public void Update(string oldid, CommentOfPhoto entity)
        {
            throw new NotImplementedException();
        }
    }
}
