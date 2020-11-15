using System.ComponentModel.DataAnnotations;

namespace DataServiceLib.DBObjects
{
    public class TitleBasics
    {
        public string Tconst { get; set; }
        public string TitleType { get; set; }
        public string PrimaryTitle { get; set; }
        public string OriginalTitle { get; set; }
        public bool IsAdult { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public int RunTimeMinutes { get; set; }
        public string Poster { get; set; }
        public string Awards { get; set; }
        public string Plot { get; set; }
        public int AvarageRating { get; set; }
        public int NumVotes { get; set; }
    }
}