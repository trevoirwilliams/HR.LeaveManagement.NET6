using HR.LeaveManagement.API.Controllers;
using HR.LeaveManagement.Application.Contracts.Identity;
using HR.LeaveManagement.Application.DTOs.Employee;
using HR.LeaveManagement.Application.UnitTests.Mocks;
using HR.LeaveManagement.Identity.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HR.LeaveManagement.Application.UnitTests.Controllers
{
    public class EmployeeControllerTest
    {
        private Mock<IUserService> _userServiceMock;

        public EmployeeControllerTest()
        {
            _userServiceMock = new Mock<IUserService>();
        }

        const string _birthPlace = "Chiprovci";

        [Fact]
        public async Task GetEmployeeByIdShouldReturnCorrectEmployee()
        {

            _userServiceMock.Setup(x => x.GetEmployeeById(It.IsAny<string>())).ReturnsAsync(new EmployeeDetailsDto { BirthPlace = _birthPlace });

            var controller = new EmployeeController(_userServiceMock.Object);

            var result = await controller.Get("asdasd");


            _userServiceMock.Verify(x => x.GetEmployeeById(It.IsAny<string>()), Times.Once);

            Assert.Equal(_birthPlace, result.BirthPlace);

        }
[Fact]
        public void GetAllEmployees()
        {
            
            //arrange
            var employeeController = new EmployeeController(Mock.Of<IUserService>());
            //act
            var result = employeeController.Get();
            //assert
            Assert.NotNull(result);
        }
    }
}

