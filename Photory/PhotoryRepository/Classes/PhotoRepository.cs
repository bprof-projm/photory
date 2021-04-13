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
    public class PhotoRepository : IPhotoRepository
    {

        private PhotoryDbContext context = new PhotoryDbContext();

        public PhotoRepository(PhotoryDbContext context)
        {
            this.context = context;
        }






        public IQueryable<Comment> GetAllCommentsFromPhoto(string PhotoID)
        {
            var entities = from x in context.Comments
                           where x.PhotoID == PhotoID
                           select x;

            return entities;
        }

        public Photo GetOnePhoto(string PhotoID)
        {
            var entities = (from x in context.Photos
                           where x.PhotoID == PhotoID
                           select x).FirstOrDefault();

            return entities;
        }
    }
}
