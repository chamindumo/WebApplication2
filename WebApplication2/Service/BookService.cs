using AutoMapper;
using com.sun.org.apache.xpath.@internal.operations;
using com.sun.xml.@internal.bind.v2.model.core;
using java.awt.print;
using WebApplication2.Data;
using WebApplication2.DTO;
using WebApplication2.Models;
using WebApplication2.Repositery;
using WebApplication2.Service;

namespace WebApplication2.Profiles
{
    public class BookService : IBookService
    {
        private readonly IMapper _mapper;
        private readonly BookRepository _bookRepository;
        private readonly DataContext _context;


        public BookService(IMapper mapper, BookRepository bookRepository, DataContext context)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
            _context = context;
        }    

       public async Task Create(BookDTO bookDTO)
        {
            var book = _mapper.Map<BookDTO, Books>(bookDTO);
           

            _bookRepository.AddBookAsync(book);
        }

       public async Task Update(int id , BookDTO bookDTO)
        {
            var book = _mapper.Map<Books>(bookDTO);
          

            _bookRepository.UpdateBookAsync(id, book);


        }
    }
}
