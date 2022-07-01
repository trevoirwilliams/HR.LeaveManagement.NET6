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
        const string _birthPlace = "Chiprovci";

        private Mock<IUserService> _userServiceMock;

        public EmployeeControllerTest()
        {
            _userServiceMock = new Mock<IUserService>();
        }

        [Fact]
        public async Task GetEmployeeByIdShouldReturnCorrectEmployee()
        {
            //Arange
            _userServiceMock.Setup(x => x.GetEmployeeById(It.IsAny<string>())).ReturnsAsync(new EmployeeDetailsDto { BirthPlace = _birthPlace });
            var controller = new EmployeeController(_userServiceMock.Object);

            //Act
            var result = await controller.Get("someRandomStringId");

            //Assert
            _userServiceMock.Verify(x => x.GetEmployeeById(It.IsAny<string>()), Times.Once);
            Assert.Equal(_birthPlace, result.BirthPlace);

        }

        [Fact]
        public async Task GetAllEmployees()
        {
            var employees = new List<AllEmployeesDto>();
            employees.Add(new AllEmployeesDto { FirstName = "Ivan" });
            employees.Add(new AllEmployeesDto { FirstName = "Valio" });
            employees.Add(new AllEmployeesDto { FirstName = "Teodor" });


            _userServiceMock.Setup(x => x.GetAllEmployees()).ReturnsAsync(employees);
            //arrange
            var controller = new EmployeeController(_userServiceMock.Object);
            //act
            var result = await controller.Get();
            _userServiceMock.Verify(x => x.GetAllEmployees(), Times.Once);
            //assert
            Assert.Equal(3, result.Count);
        }
    }
}

