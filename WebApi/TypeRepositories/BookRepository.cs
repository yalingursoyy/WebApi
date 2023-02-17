using WebApi.Data;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.TypeRepositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(AppDbContext context) : base(context)
        {
        }
    }
}
