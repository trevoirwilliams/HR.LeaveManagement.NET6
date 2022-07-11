using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Identity;
using HR.LeaveManagement.Application.DTOs.Employee;
using HR.LeaveManagement.Application.DTOs.Identity;
using HR.LeaveManagement.Application.DTOs.Identity.Validators;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Models.Identity;
using HR.LeaveManagement.Application.Responses;
using HR.LeaveManagement.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthService _authService;
        private readonly IMapper mapper;

        public UserService(UserManager<ApplicationUser> userManager, IAuthService authService, IMapper mapper )
        {
            _userManager = userManager;
            _authService = authService;
            this.mapper = mapper;
        }

        public async Task<List<AllEmployeesDto>> GetAllEmployees()
        {
            return await mapper.ProjectTo<AllEmployeesDto>(_userManager.Users).ToListAsync();
        }

        public async Task<Employee> GetEmployee(string userId)
        {
            var employee = await _userManager.FindByIdAsync(userId);
            return new Employee
            {
                Email = employee.Email,
                Id = employee.Id,
                Firstname = employee.FirstName,
                Lastname = employee.LastName
            };
        }

        public async Task<EmployeeDetailsDto> GetEmployeeById(string userId)
        {
            var employee = await _userManager.FindByIdAsync(userId);
            return mapper.Map<EmployeeDetailsDto>(employee);
        }

        public async Task<List<Employee>> GetEmployees()
        {
            var employees = await _userManager.GetUsersInRoleAsync("Employee");
            return employees.Select(q => new Employee
            {
                Id = q.Id,
                Email = q.Email,
                Firstname = q.FirstName,
                Lastname = q.LastName
            }).ToList();
        }

        public async Task<BaseCommandResponse> RegisterEmployee(RegisterEmployeeDto registerEmployeeDto)
        {
            var response = new BaseCommandResponse();
            var validator = new RegisterEmployeeDtoValidator();
            var validationResult = validator.ValidateAsync(registerEmployeeDto).Result;
            response.Errors = new List<string>();


            if (validationResult.IsValid == false)
            {
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
                response.Message = "Creation unsuccessful";
                response.Success = false;
            }

            var result = new RegistrationResponse();
            try
            {
                result = await _authService.Register(registerEmployeeDto);

            }
            catch (ValidationException ex)
            {
                response.Errors.AddRange(ex.Errors);
                response.Success = false;
                response.Message = "Creation unsuccessful";
                return response;
            }

            response.Success = true;
            response.Message = $"UserId = {result.UserId}";
            return response;
        }

       
    }
}
