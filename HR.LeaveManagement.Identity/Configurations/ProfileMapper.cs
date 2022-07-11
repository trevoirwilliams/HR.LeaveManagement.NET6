using AutoMapper;
using HR.LeaveManagement.Application.DTOs.Employee;
using HR.LeaveManagement.Application.DTOs.Identity;
using HR.LeaveManagement.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Identity.Configurations
{
    public class ProfileMapper : Profile
    {
        public ProfileMapper()
        {
            CreateMap<RegisterEmployeeDto, ApplicationUser>().ReverseMap();
            CreateMap<AllEmployeesDto, ApplicationUser>().ReverseMap();
            CreateMap<EmployeeDetailsDto, ApplicationUser>().ReverseMap();
        }
    }
}
