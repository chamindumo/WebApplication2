using WebApplication2.DTO;
using WebApplication2.Models;

namespace WebApplication2.Service
{
    public interface IBookServices
    {
        Books Map(BookDTO source);
        BookDTO Map(Books source);
    }
}
