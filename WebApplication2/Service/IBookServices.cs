using WebApplication2.DTO;
using WebApplication2.Models;

namespace WebApplication2.Service
{
    public interface IBookService
    {
        void Create(BookDTO bookDTO);

        void Update(BookDTO bookDTO);
    }
}
