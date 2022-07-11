using HR.LeaveManagement.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.UnitTests.Mocks
{
    public static class DatabaseMock
    {
        public static LeaveManagementIdentityDbContext Instance
        {
            get
            {
                var dbContextOptions = new DbContextOptionsBuilder<LeaveManagementIdentityDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .Options;

                return new LeaveManagementIdentityDbContext(dbContextOptions);
            }
        }
    }
}
