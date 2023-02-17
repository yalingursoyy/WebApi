namespace WebApi.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IBookRepository Book { get; }
        IPeopleRepository Person { get; }

        int Save();
    }
}
