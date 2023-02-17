using WebApi.Data;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.TypeRepositories
{
    public class PeopleRepository : GenericRepository<Person>, IPeopleRepository
    {
        public PeopleRepository(AppDbContext context) : base(context)
        {
        }
    }
}
