using PhotoryModels;
using System.Linq;

namespace PhotoryRepository.Interfaces
{
    public interface IPhotoRepository
    {
        Photo GetOnePhoto(string PhotoID);

        IQueryable<Comment> GetAllCommentsFromPhoto(string PhotoID);

        Photo GetOneRescaledPhoto(string PhotoID);

        void DeletePhoto(string PhotoID);
    }
}