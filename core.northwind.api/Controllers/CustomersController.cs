using corenorthwindapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace corenorthwindapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersService _customerRep;

        public CustomersController(ICustomersService customerRep)
        {
            _customerRep = customerRep;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var customers = await _customerRep.GetAllAsync();
            return Ok(customers);
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            var customers = await _customerRep.GetOneAsync(id);
            return Ok(customers);
        }

        // POST api/<CustomersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}
