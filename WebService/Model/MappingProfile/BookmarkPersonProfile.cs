using AutoMapper;
using DataServiceLib.DBObjects;

namespace ProjectPortfolio2_Group11.Model.MappingProfile
{
    public class BookmarkPersonProfile : Profile
    {
        public BookmarkPersonProfile()
        {
            CreateMap<BookmarkPerson, BookmarkPersonDto>();
            CreateMap<BookmarkPersonForCreationDto, BookmarkPerson>();
        }
    }
}