using HR.LeaveManagement.Application.DTOs.Employee;
using HR.LeaveManagement.Application.DTOs.Identity;
using HR.LeaveManagement.Application.Models.Identity;
using HR.LeaveManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Contracts.Identity
{
    public interface IUserService
    {
        Task<List<AllEmployeesDto>> GetAllEmployees();
        Task<List<Employee>> GetEmployees();
        Task<Employee> GetEmployee(string userId);
        Task<BaseCommandResponse> RegisterEmployee(RegisterEmployeeDto registerEmployeeDto);
        Task<EmployeeDetailsDto> GetEmployeeById(string userId);
    }
}
