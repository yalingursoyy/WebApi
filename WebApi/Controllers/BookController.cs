using Microsoft.AspNetCore.Mvc;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public BookController (IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IEnumerable<Book>> Get()
        {
            return await unitOfWork.Book.Get();
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]

        public async Task<IActionResult> Add(Book entity)
        {
            await unitOfWork.Book.Add(entity);
            return CreatedAtAction(nameof(Get), new { id = entity.Id }, entity);
        }

        [HttpPut("id")]
        public async Task<IActionResult> Update(int id, Book entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();
            }
            await unitOfWork.Book.Update(id, entity);
            return NoContent();
        }
        [HttpDelete]
        public void Delete(Book entity)
        {
            unitOfWork.Book.Delete(entity);
        }

    }
}
