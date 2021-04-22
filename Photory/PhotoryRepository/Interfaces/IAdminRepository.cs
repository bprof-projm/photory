using PhotoryModels;

namespace PhotoryRepository.Interfaces
{
    public interface IAdminRepository : IRepository<User>
    {
        //CREATE GROUP
        void CreateGroup(Group group);//CreateGroup();

        //ADD-MEMBER TO GROUP
        void AddMember(string userID, string GroupID);
    }
}