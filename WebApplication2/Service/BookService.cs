using AutoMapper;
using WebApplication2.DTO;
using WebApplication2.Models;

namespace WebApplication2.Profiles
{
    public class BookService : Profile
    {
        public BookService()
        {
            CreateMap<BookDTO, Books>();
            CreateMap<Books, BookDTO>();

        }

    }
}
