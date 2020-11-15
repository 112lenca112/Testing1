using DataServiceLib.DataService;
using DataServiceLib.IDataService;
using Microsoft.Extensions.Configuration;

namespace DataServiceLib
{
    public class DataServiceFacade
    {
        public readonly IBookmarkingDataService BookmarkingDS;
        public readonly IRatingDataService RatingDS;
        public readonly IUsersDataService UsersDS;
        public readonly ISearchDataService SearchDS;
        
        public DataServiceFacade(IConfiguration configuration)
        {
            var connStr = configuration.GetSection("connectionString").Value;
            
            BookmarkingDS = new BookmarkingDataService(connStr);
            RatingDS = new RatingDataService(connStr);
            UsersDS = new UsersDataService(connStr);
            SearchDS = new SearchDataService(connStr);
        }
    }
}