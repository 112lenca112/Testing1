using DataServiceLib.DBObjects;

namespace DataServiceLib.IDataService
{
    public interface IUsersDataService
    {
        Users GetUser(int userId);
        void CreateUser(Users user);
        bool DeleteUser(int userId);
        bool UpdateUser(Users user);
        bool Login();
        bool Logout();
    }
}