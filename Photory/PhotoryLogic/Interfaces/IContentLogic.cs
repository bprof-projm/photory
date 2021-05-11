using PhotoryModels;
using System.Linq;

namespace PhotoryLogic.Interfaces
{
    public interface IContentLogic
    {
        IQueryable<Comment> GetAllCommentsFromPhoto(string PhotoID);

        Photo GetOnePhoto(string photoid);

        IQueryable<Photo> GetPhotosFromGroup(string GroupID);

        IQueryable<Group> GetAllGroup();
    }
}