using PhotoryModels;
using System.Linq;

namespace PhotoryRepository.Interfaces
{
    public interface IGroupRepository : IRepository<Group>
    {
        IQueryable<Photo> GetPhotosFromGroup(string GroupID);
    }
}