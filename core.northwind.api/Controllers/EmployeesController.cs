using corenorthwindapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace corenorthwindapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        private readonly IEmployeesService _employeeRep;

        public EmployeesController(IEmployeesService employeeRep)
        {
            _employeeRep = employeeRep;
        }

        // GET: api/<EmployeesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var employees = await _employeeRep.GetAllAsync();
            return Ok(employees);
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var employees = await _employeeRep.GetOneAsync(id);
            return Ok(employees);
        }

        //// POST api/<EmployeesController>
        //[HttpPost]
        //public async Task<int> Post([FromBody] string value)
        //{
        //    return CreatedAtAction();
        //}

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
