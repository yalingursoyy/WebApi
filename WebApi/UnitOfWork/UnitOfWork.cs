using WebApi.Data;
using WebApi.Interfaces;
using WebApi.Models;
using WebApi.TypeRepositories;

namespace WebApi.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork
    {
        private AppDbContext context;
        public UnitOfWork (AppDbContext context)
        {
            this.context = context;
            Person = new PeopleRepository(this.context);
            Book = new BookRepository(this.context);
        }
        public IPeopleRepository Person
        {
            get;
            set;
        }
        public IBookRepository Book
        {
            get;
            set;
        }
        public void Dispose()
        {
            context.Dispose();
        }
        public int Save()
        {
            return context.SaveChanges();
        }
    }
}
