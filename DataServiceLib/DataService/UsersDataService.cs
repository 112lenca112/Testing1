using System;
using System.Linq;
using DataServiceLib.DBObjects;
using DataServiceLib.IDataService;

namespace DataServiceLib.DataService
{
    public class UsersDataService : IUsersDataService
    {
        private readonly Raw11Context _db;
        
        public UsersDataService(string connStr)
        {
            _db = new Raw11Context(connStr);
        }
        
        public Users GetUser(int userId)
        {
            return _db.Users.FirstOrDefault(x => x.UserId == userId);
        }
        
        public void CreateUser(Users user)
        {
            var maxId = _db.Users.Max(x => x.UserId);
            user.UserId = maxId + 1;
            _db.Users.Add(user);
            _db.SaveChanges();
        }

        public bool UpdateUser(Users user)
        {
            var dbUser = GetUser(user.UserId);
            if (dbUser == null)
            {
                return false;
            }
            dbUser.UserId = user.UserId;
            dbUser.Name = user.Name;
            dbUser.Age = user.Age;
            dbUser.Language = user.Language;
            dbUser.Mail = user.Mail;
            _db.SaveChanges();
            return true;
        }

        public bool DeleteUser(int userId)
        {
            var dbUser = GetUser(userId);
            if (dbUser == null)
            {
                return false;
            }
            _db.Users.Remove(dbUser);
            _db.SaveChanges();
            return true;
        }

        public bool Login()
        {
            throw new NotImplementedException();
        }

        public bool Logout()
        {
            throw new NotImplementedException();
        }
    }
}