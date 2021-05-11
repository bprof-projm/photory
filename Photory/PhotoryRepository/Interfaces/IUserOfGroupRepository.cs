using PhotoryModels;
using System.Linq;

namespace PhotoryRepository.Interfaces
{
    public interface IUserOfGroupRepository : IRepository<UserOfGroup>
    {
        IQueryable<UserOfGroup> GetAllPendingUser();

        IQueryable<UserOfGroup> GetAllAcceptedUser();
    }
}