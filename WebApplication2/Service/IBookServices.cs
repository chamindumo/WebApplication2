using WebApplication2.DTO;
using WebApplication2.Models;

namespace WebApplication2.Service
{
    public interface IBookService
    {
        Task Create(BookDTO bookDTO);
        Task Update(int id , BookDTO bookDTO);
    }
}
