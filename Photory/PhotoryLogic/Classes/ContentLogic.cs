using PhotoryLogic.Interfaces;
using PhotoryModels;
using PhotoryRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoryLogic.Classes
{
    public class ContentLogic : IContentLogic
    {
        private IGroupRepository grouprepo;
        private IPhotoRepository photorepo;


        public ContentLogic(IGroupRepository grouprepo, IPhotoRepository photorepo)
        {
            this.grouprepo = grouprepo;
            this.photorepo = photorepo;
        }

        public IQueryable<Comment> GetAllCommentsFromPhoto(string PhotoID)
        {
           return photorepo.GetAllCommentsFromPhoto(PhotoID);
        }

        public IQueryable<Group> GetAllGroup()
        {
            return grouprepo.GetAll();
        }

        public Photo GetOnePhoto(string photoid)
        {
            return photorepo.GetOnePhoto(photoid);
        }

        public IQueryable<Photo> GetPhotosFromGroup(string GroupID)
        {
           return grouprepo.GetPhotosFromGroup(GroupID);
        }
    }
}
