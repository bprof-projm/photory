using PhotoryModels;

namespace PhotoryRepository.Interfaces
{
    public interface IGroupAdminRepository : IRepository<User>
    {
        //ACCEPT USER
        void AcceptUser(string userID, string GroupID);

        //DENY USER
        void DenyUser(string userID, string GroupID);
    }
}