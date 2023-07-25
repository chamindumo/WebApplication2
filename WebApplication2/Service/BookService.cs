using AutoMapper;
using WebApplication2.DTO;
using WebApplication2.Models;
using WebApplication2.Repositery;
using WebApplication2.Service;

namespace WebApplication2.Profiles
{
    public class BookService : Profile, IBookService
    {
        private readonly IMapper _mapper;
        private readonly IBookRepositery _bookRepository;
        public BookService()
        {
            CreateMap<BookDTO, Books>();
            CreateMap<Books, BookDTO>();

        }

        public void Create(BookDTO bookDTO)
        {
            var book = _mapper.Map<Books>(bookDTO);
            _bookRepository.AddBookAsync(book);
        }

        public void Update(BookDTO bookDTO)
        {
            var book = _mapper.Map<Books>(bookDTO);
            int id = book.Id;
            _bookRepository.UpdateBookAsync(id,book);
        }
    }
}
