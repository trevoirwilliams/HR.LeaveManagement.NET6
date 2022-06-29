using HR.LeaveManagement.Application.Contracts.Identity;
using HR.LeaveManagement.Application.DTOs.Employee;
using HR.LeaveManagement.Application.DTOs.Identity;
using HR.LeaveManagement.Application.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _authenticationService;
        private readonly IUserService _userService;

        public AccountController(IAuthService authenticationService, IUserService userService)
        {
            _authenticationService = authenticationService;
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
        {
            return Ok(await _authenticationService.Login(request));
        }

        //[HttpPost("register")]
        //public async Task<ActionResult<RegistrationResponse>> Register(RegistrationRequest request)
        //{
        //    return Ok(await _authenticationService.Register(request));
        //}
        [HttpPost("registerEmployee")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<RegistrationResponse>> RegisterEmployee([FromBody] RegisterEmployeeDto request)
        {
            if (ModelState.IsValid)
            {

            }
            var result = await _userService.RegisterEmployee(request);

            return result;
        }

        [HttpGet]
        public async Task<List<AllEmployeesDto>> Get()
        {
            var allEmployees = await _userService.GetAllEmployees();
            return allEmployees;
        }
    }
}
