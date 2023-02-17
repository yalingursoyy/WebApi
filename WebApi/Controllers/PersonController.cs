using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public PersonController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        [ProducesResponseType(typeof(Person),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<Person>> Get()

        {
            return await unitOfWork.Person.Get();
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]

        public async Task<IActionResult> Add(Person entity)
        {
            await unitOfWork.Person.Add(entity);
            return CreatedAtAction(nameof(Get),new {id=entity.Id}, entity);
        }
        [HttpPut("id")]
        public async Task<IActionResult> Update(int id,Person entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();
            }
            await unitOfWork.Person.Update(id,entity);
            return NoContent();
        }
        [HttpDelete]
        public void Delete(Person entity)
        {
            unitOfWork.Person.Delete(entity);
        }


    }
}
