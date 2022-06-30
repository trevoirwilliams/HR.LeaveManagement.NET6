using HR.LeaveManagement.Api.Controllers;
using HR.LeaveManagement.Application.Contracts.Identity;
using HR.LeaveManagement.Application.DTOs.Identity;
using HR.LeaveManagement.Application.Models.Identity;
using HR.LeaveManagement.Application.Responses;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HR.LeaveManagement.Application.UnitTests.Controllers
{
    public class AccountControllerTest
    {
        private Mock<IUserService> _userServiceMock;
        private Mock<IAuthService> _authServiceMock;


        public AccountControllerTest()
        {
            _userServiceMock = new Mock<IUserService>();
            _authServiceMock = new Mock<IAuthService>();
        }

        [Fact]
        public async Task CreateEmployeeTest()
        {
            var registerEmployeeDto = new RegisterEmployeeDto();
            var baseCommandResponse = new BaseCommandResponse();
            var registrationResponse = new RegistrationResponse();

            _userServiceMock.Setup(x => x.RegisterEmployee(registerEmployeeDto)).ReturnsAsync(baseCommandResponse);
            _authServiceMock.Setup(x => x.Register(registerEmployeeDto)).ReturnsAsync(registrationResponse);

            var controller = new AccountController(_authServiceMock.Object, _userServiceMock.Object);

            var result = await controller.RegisterEmployee(registerEmployeeDto);

            _userServiceMock.Verify(x => x.RegisterEmployee(registerEmployeeDto), Times.Once);

            Assert.True(result.Value.Success);
        }
    }
}
