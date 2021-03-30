using PhotoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
