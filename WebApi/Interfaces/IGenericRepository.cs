using Microsoft.AspNetCore.Mvc;

namespace WebApi.Interfaces
{
    public interface IGenericRepository <T> where T : class
    {

        public Task<IActionResult> Add(T entity);
        public Task<IActionResult> Update(int id,T entity);
        public void Delete(T entity);
        public Task<IEnumerable<T>> Get();
        
    }
}
