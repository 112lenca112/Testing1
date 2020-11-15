using System;
using System.Collections.Generic;
using System.Linq;
using DataServiceLib.DBObjects;
using DataServiceLib.IDataService;

namespace DataServiceLib.DataService
{
    public class RatingDataService : IRatingDataService
    {
        private readonly Raw11Context _db;

        public RatingDataService(string connStr)
        {
            _db = new Raw11Context(connStr);
        }
        
        public IList<UserNameRate> GetRatingList()
        {
            return _db.UserNameRates.ToList();
        }

        public UserNameRate GetRating(int userId)
        {
            return _db.UserNameRates.FirstOrDefault(x => x.UserId == userId); 
        }
        
        public void CreateRating(UserNameRate userNameRate)
        {
            var maxId = _db.UserNameRates.Max(x => x.UserId);
            userNameRate.UserId = maxId + 1;
            _db.UserNameRates.Add(userNameRate);
            _db.SaveChanges();
        }

        public bool UpdateRating(UserNameRate userNameRate)
        {
            var dbUserNameRate = GetRating(userNameRate.UserId);
            if (dbUserNameRate == null)
            {
                return false;
            }

            dbUserNameRate.UserId = userNameRate.UserId;
            dbUserNameRate.NameIndividRating = userNameRate.NameIndividRating;
            dbUserNameRate.Nconst = userNameRate.Nconst;
            dbUserNameRate.DateTime = userNameRate.DateTime;
            _db.SaveChanges();
            return true;
        }
        
        public bool DeleteRating(int userId)
        {
            var dbUserNameRate = GetRating(userId);
            if (dbUserNameRate == null)
            {
                return false;
            }
            _db.UserNameRates.Remove(dbUserNameRate);
            _db.SaveChanges();
            return true;
        }
    }
}