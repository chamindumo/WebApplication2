using AutoMapper;
using WebApplication2.Data;
using WebApplication2.DTO;
using WebApplication2.Models;
using WebApplication2.Repositery;

namespace WebApplication2.Service
{
    public class BookServices1 : IBookService
    {
        private readonly IMapper _mapper;
        private readonly BookRepository _bookRepository;
        private readonly DataContext _context;


        public BookServices1(IMapper mapper, BookRepository bookRepository, DataContext context)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
            _context = context;
        }
        public void Create(BookDTO bookDTO)
        {
            var book = _mapper.Map<BookDTO, Books>(bookDTO);

            _bookRepository.AddBookAsync(book);
        }

        public void Update(int id, BookDTO bookDTO)
        {
            var book = _mapper.Map<BookDTO, Books>(bookDTO);


            _bookRepository.UpdateBookAsync(id, book);
        }
    }
}
