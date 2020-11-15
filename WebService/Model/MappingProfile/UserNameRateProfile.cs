using AutoMapper;
using DataServiceLib.DBObjects;

namespace ProjectPortfolio2_Group11.Model.MappingProfile
{
    public class UserNameRateProfile : Profile
    {
        public UserNameRateProfile()
        {
            CreateMap<UserNameRate, UserNameRateDto>();
            CreateMap<UserNameRateForCreationDto, UserNameRate>();
        }
    }
}