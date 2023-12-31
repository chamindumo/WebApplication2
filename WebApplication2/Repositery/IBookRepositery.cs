﻿using WebApplication2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace WebApplication2.Repositery
{
    public interface IBookRepositery
    {
        Task<List<Books>> GetAllBooksAsync();
        Task<Books> GetBookByIdAsync(int id);
        Task AddBookAsync(Books book);
        Task UpdateBookAsync(int id, Books book);
        Task DeleteBookAsync(int id);
    }
}

