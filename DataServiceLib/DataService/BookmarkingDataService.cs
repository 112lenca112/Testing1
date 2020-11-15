using System.Collections.Generic;
using System.Linq;
using DataServiceLib.DBObjects;
using DataServiceLib.IDataService;

namespace DataServiceLib.DataService
{
    public class BookmarkingDataService : IBookmarkingDataService
    {
        private readonly Raw11Context _db;
        
        public BookmarkingDataService(string connStr)
        {
            _db = new Raw11Context(connStr);
        }
        
      

        public BookmarkPerson GetBookMark(int userid, string nconst)
        {

            return _db.BookmarkPerson.FirstOrDefault(x => x.UserId==userid 
                                                    && x.Nconst == nconst);
        }

        public void CreateBookmark(BookmarkPerson bookmarkPerson)
        { 
            _db.BookmarkPerson.Add(bookmarkPerson);
            _db.SaveChanges();
        }
        
        public bool UpdateBookmark(BookmarkPerson bookmarkPerson)
        {
            var dbBook = GetBookMark(bookmarkPerson.UserId,bookmarkPerson.Nconst);
            if (dbBook == null)
            {
                return false;
            }

            dbBook.UserId = bookmarkPerson.UserId;
            dbBook.Nconst = bookmarkPerson.Nconst; 
            _db.SaveChanges();
            return true;
        }

        public bool DeleteBookmark(int userid, string nconst)
        {
            var dbBook = GetBookMark(userid,nconst);
            if (dbBook == null)
            {
                return false;
            }
            _db.BookmarkPerson.Remove(dbBook);
            _db.SaveChanges();
            return true;
        }
    }
}