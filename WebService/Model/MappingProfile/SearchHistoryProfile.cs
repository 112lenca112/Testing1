using AutoMapper;
using DataServiceLib.DBObjects;

namespace ProjectPortfolio2_Group11.Model.MappingProfile
{
    public class SearchHistoryProfile : Profile
    {
        public SearchHistoryProfile()
        {
            CreateMap<SearchHistory, SearchHistoryDTO>();
            
        }
    }
}