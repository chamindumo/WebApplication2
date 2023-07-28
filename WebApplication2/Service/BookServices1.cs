using AutoMapper;
using java.awt.print;
using WebApplication2.Data;
using WebApplication2.DTO;
using WebApplication2.Models;
using WebApplication2.Repositery;

namespace WebApplication2.Service
{
    public class BookServices1 : IBookService
    {
        private readonly IMapper _mapper;
        private readonly IBookRepositery _bookRepository;


        public BookServices1(IMapper mapper, IBookRepositery bookRepository)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
        }
        public void Create(BookDTO bookDTO)
        {
            var book = _mapper.Map< Books>(bookDTO);

            _bookRepository.AddBookAsync(book);

        }

        public Books GetAllBooks()
        {
            var books = _bookRepository.GetAllBooksAsync(); // Call the repository method to fetch books from the database
            return _mapper.Map<Books>(books);
        }

        public Books GetBookById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, BookDTO bookDTO)
        {
            var book = _mapper.Map< Books>(bookDTO);


            _bookRepository.UpdateBookAsync(id, book);
        }

       
    }
}
