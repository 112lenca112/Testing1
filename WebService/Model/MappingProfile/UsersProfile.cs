using AutoMapper;
using DataServiceLib.DBObjects;

namespace ProjectPortfolio2_Group11.Model.MappingProfile
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<Users, UsersDto>();
            CreateMap<UsersForCreationDto, Users>();
        }
    }
}