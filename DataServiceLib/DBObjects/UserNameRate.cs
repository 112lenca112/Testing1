using System;
using System.ComponentModel.DataAnnotations;

namespace DataServiceLib.DBObjects
{
    public class UserNameRate
    {
        public int UserId { get; set; }
        public int NameIndividRating { get; set; }
        public string Nconst { get; set; }
        public DateTime DateTime { get; set; }
    }
}