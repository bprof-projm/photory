using PhotoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhotoryRepository.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {

        //ADD PHOTO
        public void AddPhoto(Photo p);

        //ADD COMMENT
        public void AddComment(Comment m);

        //REQUEST JOIN
        public void RequestJoin(string userid,string GroupID);//??userid

        //DELETE PHOTO
        public void DeletePhoto(string PhotoID);


        //DELETE COMMENT
        public void DeleteComment(string CommentID);

        IQueryable<Comment> GetAllCommentsFromPhoto(string photoID);



    }
}
