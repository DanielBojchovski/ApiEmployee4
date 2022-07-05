using ApiEmployee4.Models;
using ApiEmployee4.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiEmployee4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NameSearchController : ControllerBase
    {
        private readonly IEmployeeRepository _empRepository;

        public NameSearchController(IEmployeeRepository empRepository)
        {
            _empRepository = empRepository;
        }

        [HttpGet("{name}", Name = "Search the employee by name./ Пребарај го вработениот по име.")]
        public async Task<ActionResult<IEnumerable<Employee>>> SearchByName(string name)
        {
            try
            {
                var result = await _empRepository.SearchByName(name);
                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound($"Employee with name = {name} was not found./ Вработен со име = {name} не беше пронајден");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error retrieving data from the database./ Грешка при превземањето на податоци од базата");
            }
        }
    }
}
