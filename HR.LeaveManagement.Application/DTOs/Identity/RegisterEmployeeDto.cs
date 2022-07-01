using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.DTOs.Identity
{
    public class RegisterEmployeeDto
    {
        public string Password { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string BirthPlace { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string IdCard { get; set; }
        public string CardAuthority { get; set; }
        public string IBAN { get; set; }
        public string BankDetails { get; set; }
        public int WorkExperienceInDays { get; set; }
        public DateTime StartDate { get; set; }
        public int? WorkExperienceInCompanyInDays { get; set; }
        public int VacationHours { get; set; }
        public string Office { get; set; }
        public string Discipline { get; set; }
    }
}
