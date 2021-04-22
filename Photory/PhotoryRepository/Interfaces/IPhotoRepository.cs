using PhotoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoryRepository.Interfaces
{
    public interface IPhotoRepository
    {

        Photo GetOnePhoto(string PhotoID);
         IQueryable<Comment> GetAllCommentsFromPhoto(string PhotoID);
        Photo GetOneRescaledPhoto(string PhotoID);

    }
}
