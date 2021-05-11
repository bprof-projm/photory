using PhotoryModels;
using System.Linq;

namespace PhotoryRepository.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        //ADD PHOTO
         void AddPhoto(Photo p);

        //ADD COMMENT
        void AddComment(Comment m);

        //REQUEST JOIN
         void RequestJoin(string userid, string GroupID);//??userid

        //DELETE PHOTO
         void DeletePhoto(string PhotoID);

        //DELETE COMMENT
         void DeleteComment(string CommentID);

        IQueryable<Comment> GetAllCommentsFromPhoto(string photoID);

        void LeaveGroup(string userID, string GroupID);
    }
}