using ApiEmployee4.Models;
using ApiEmployee4.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiEmployee4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetSalariesBiggerThanValueController : ControllerBase
    {
        private readonly IEmployeeRepository _empRepository;

        public GetSalariesBiggerThanValueController(IEmployeeRepository empRepository)
        {
            _empRepository = empRepository;
        }

        [HttpGet("{salary}", Name = "Search the employees with salary bigger than your value./ Пребарај ги вработените со плата поголема од вашата вредност.")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetSalariesBiggerThen(decimal salary)
        {
            try
            {
                var result = await _empRepository.GetSalariesBiggerThen(salary);

                if (result.Any())
                {
                    return Ok(result);
                }

                return NotFound($"No employee with salary bigger than {salary} was not found./ Нема вработен со плата поголема од {salary}");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error retrieving data from the database./ Грешка при превземањето на податоци од базата");
            }
        }
    }
}
