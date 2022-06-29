using HR.LeaveManagement.Application.Contracts.Identity;
using HR.LeaveManagement.Application.DTOs.Employee;
using HR.LeaveManagement.Identity.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.LeaveManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IUserService userService;

        public EmployeeController(IUserService userService)
        {
            this.userService = userService;
        }

        // GET: api/<EmployeeController>//
        [HttpGet]
        public Task<List<AllEmployeesDto>> Get()
        {
            var allEmployees = userService.GetAllEmployees();
            return allEmployees;
        }

        // GET api/<EmployeeController>/5
      [HttpGet("{id}")]
      public Task<EmployeeDetailsDto> Get(string id) 
      {
            return userService.GetEmployeeById(id);
      }
      
      // POST api/<EmployeeController>
      [HttpPost]
      public void Post([FromBody] string value)
      {
      }
      
      // PUT api/<EmployeeController>/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody] string value)
      {
      }
      
      // DELETE api/<EmployeeController>/5
      [HttpDelete("{id}")]
      public void Delete(int id)
      {
      }
    }
}
