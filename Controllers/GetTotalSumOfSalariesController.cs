using ApiEmployee4.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiEmployee4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetTotalSumOfSalariesController : ControllerBase
    {
        private readonly IEmployeeRepository _empRepository;

        public GetTotalSumOfSalariesController(IEmployeeRepository empRepository)
        {
            _empRepository = empRepository;
        }

        [HttpGet(Name = "Print sum of all salaries in the company./ Печати ја сумата од платите во компанијата.")]
        public decimal GetTotalSumOfSalaries()
        {
            return _empRepository.GetTotalSumOfSalaries();
        }
    }
}
