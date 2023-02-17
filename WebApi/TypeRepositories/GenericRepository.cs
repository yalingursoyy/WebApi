using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using WebApi.Data;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.TypeRepositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext context;
        public GenericRepository(AppDbContext context)
        {
            this.context = context;
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult>  Add(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
            return null;

        }
        public async Task<IActionResult> Update(int id,T entity)
        {

            context.Entry(entity).State= EntityState.Modified;
            await context.SaveChangesAsync();
            return null;
        }

        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }
        public async Task<IEnumerable<T>> Get()
        {
            return await context.Set<T>().ToListAsync();
        }
    }

}