using System;
using System.Collections.Generic;
using System.Linq;
using DataServiceLib.DBObjects;
using DataServiceLib.IDataService;
 
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace DataServiceLib.DataService
{
    public class SearchDataService : ISearchDataService
    {
        private readonly Raw11Context _db;
        
        public SearchDataService(string connStr)
        {
            _db = new Raw11Context(connStr);
        }
        
        public IList<SearchHistory> GetSearchHistory(int userid)
        {
            return _db.SearchHistory.Where(x => x.UserId == userid).ToList()
     
            ;
        }

        public void AddToSearchHistory(int userId, string searchInput, DateTime searchTime)
        {



            var queery = _db.SearchHistory.FromSqlInterpolated($"select * from string_search({userId},{searchInput}");
         //   _db.SearchHistory.Add();
            _db.SaveChanges();
          /*  return queery
               .ToList(); */


        }

      /*  public void AddToSearchHistory(SearchHistory searchhistory)
        {
            var dbUser = GetSearchHistory(searchhistory.UserId);
           
            dbUser.userid = searchhistory.UserId;
            dbUser.SearchInput = searchhistory.SearchInput;
            


            _db.SaveChanges();
           // return true;
        } */



    }
}