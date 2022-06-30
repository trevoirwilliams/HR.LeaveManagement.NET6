using AutoMapper;
using HR.LeaveManagement.API.Controllers;
using HR.LeaveManagement.Application.Contracts.Identity;
using HR.LeaveManagement.Application.DTOs.Employee;
using HR.LeaveManagement.Identity.Models;
using HR.LeaveManagement.Identity.Services;
using Microsoft.AspNetCore.Identity;
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
