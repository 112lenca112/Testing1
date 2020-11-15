using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectPortfolio2_Group11.Model
{
    public class SearchHistoryDTO
    {
        public int UserId { get; set; }
        public string SearchInput { get; set; }
        public DateTime DateTime { get; set; }
    }
}