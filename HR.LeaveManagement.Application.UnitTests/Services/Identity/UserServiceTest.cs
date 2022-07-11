using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Identity;
using HR.LeaveManagement.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.UnitTests.Services.Identity
{
    public class UserServiceTest
    {
        private Mock<UserManager<ApplicationUser>> _userManager;
        private Mock<IAuthService> _authService;
        private Mock<IMapper> mapper;
    }
}
