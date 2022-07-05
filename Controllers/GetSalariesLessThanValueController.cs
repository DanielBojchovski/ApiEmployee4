using ApiEmployee4.Models;
using ApiEmployee4.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiEmployee4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetSalariesLessThanValueController : ControllerBase
    {
        private readonly IEmployeeRepository _empRepository;

        public GetSalariesLessThanValueController(IEmployeeRepository empRepository)
        {
            _empRepository = empRepository;
        }

        [HttpGet("{salary}", Name = "Search the employees with salary smaller than your value./ Пребарај ги вработените со плата помала од вашата вредност.")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetSalariesLessThen(decimal salary)
        {
            try
            {
                var result = await _empRepository.GetSalariesLessThen(salary);

                if (result.Any())
                {
                    return Ok(result);
                }

                return NotFound($"No employee with salary smaller than {salary} was not found./ Нема вработен со плата помала од {salary}");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error retrieving data from the database./ Грешка при превземањето на податоци од базата");
            }
        }
    }
}
