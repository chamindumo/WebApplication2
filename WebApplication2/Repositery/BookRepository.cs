using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Service;

namespace WebApplication2.Repositery;

public class BookRepository: IBookService
{
    private readonly DataContext _context;

    public BookRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<List<Books>> GetAllBooksAsync()
    {
        return await _context.Books.ToListAsync();
    }

    public async Task<Books> GetBookByIdAsync(int id)
    {
        return await _context.Books.FindAsync(id);
    }

    public async Task AddBookAsync(Books book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateBookAsync(int id, Books book)
    {
        var existingBook = await _context.Books.FindAsync(id);
        if (existingBook == null)
            return;

        existingBook.Title = book.Title;
        existingBook.Author = book.Author;

        await _context.SaveChangesAsync();
    }

    public async Task DeleteBookAsync(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null)
            return;

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();
    }
}



