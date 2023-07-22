using AutoMapper;
using WebApplication2.DTO;
using WebApplication2.Models;

namespace WebApplication2.Profiles
{
    public class BookProfile: Profile
    {
        public BookProfile()
        {
            CreateMap<BookInputDTO, Books>();
            CreateMap<Books, BookOutputDTO>();

        }

    }
}
