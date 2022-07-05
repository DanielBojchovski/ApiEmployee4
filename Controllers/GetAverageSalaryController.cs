using ApiEmployee4.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiEmployee4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetAverageSalaryController : ControllerBase
    {
        private readonly IEmployeeRepository _empRepository;

        public GetAverageSalaryController(IEmployeeRepository empRepository)
        {
            _empRepository = empRepository;
        }

        [HttpGet(Name = "Print average salary in the company./ Печати просечна плата во компанијата.")]
        public decimal GetAverageSalary()
        {
            return _empRepository.GetAverageSalary();
        }
    }
}
