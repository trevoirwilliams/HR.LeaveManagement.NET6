using HR.LeaveManagement.Application.DTOs.Identity;
using HR.LeaveManagement.Application.DTOs.Identity.Validators;
using HR.LeaveManagement.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HR.LeaveManagement.Application.UnitTests.Services.Identity
{
    public class ValidationTest
    {

        [Theory]
        [InlineData("email@", "username", "firstName", "lastName", 23)]
        [InlineData("email@test.com", "", "firstName", "lastName", 23)]
        [InlineData("email@test.com", "username", "", "lastName", 23)]
        [InlineData("email@test.com", "username", "firstName", "", 23)]
        [InlineData("email@test.com", "username", "firstName", "lastName", 0)]
        public async Task RegisterEmployeeValidationTest(string email, string username, string firstName, string lastName, 
            /*string birthPlace, string country, string address, string idCard, string cardAuthority, string iban*/ int vacationHours)
        {
            var employee = new RegisterEmployeeDto()
            {
                Password = "P@ssword1",
                Email = email,
                Username = username,
                FirstName = firstName,
                LastName = lastName,
                BirthPlace = "sofia",
                Country = "asdad",
                Address = "123 asd",
                IdCard = "999999999",
                CardAuthority = "sadfasf",
                IBAN = "sfdsdfsdfsdfds",
                BankDetails = "testtest",
                WorkExperienceInDays = 12,
                StartDate = DateTime.Now,
                WorkExperienceInCompanyInDays = 10,
                Office = "asdasd",
                Discipline = "testest",
                MiddleName = "middlename",
                VacationHours = vacationHours
            };
            var validator = new RegisterEmployeeDtoValidator();
            var result = await validator.ValidateAsync(employee);

            Assert.NotNull(result);
            Assert.False(result.IsValid);
            Assert.True(result.Errors.Count == 1);
        }
    }
}
