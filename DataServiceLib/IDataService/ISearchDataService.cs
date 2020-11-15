using System;
using System.Collections.Generic;
using DataServiceLib.DBObjects;

namespace DataServiceLib.IDataService
{
    public interface ISearchDataService
    {
        //SearchHistory GetSearchHistory(int userId);
        void AddToSearchHistory(int userId, string searchInput, DateTime searchTime);

        IList<SearchHistory> GetSearchHistory(int userid);
    }
}