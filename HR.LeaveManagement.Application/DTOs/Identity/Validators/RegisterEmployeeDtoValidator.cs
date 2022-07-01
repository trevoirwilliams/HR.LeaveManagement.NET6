using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.DTOs.Identity.Validators
{
    public class RegisterEmployeeDtoValidator : AbstractValidator<RegisterEmployeeDto>
    {
        public RegisterEmployeeDtoValidator()
        {
            /*RuleFor(a => a.Password)
                .MinimumLength(6).WithMessage("{PropertyName} must be at least {ComparisonValue} digits")
                .NotEmpty().WithMessage("Please enter password");*/

            RuleFor(a => a.Email)
                .NotEmpty().WithMessage("Email address is required.")
                .EmailAddress().WithMessage("A valid email address is required.")
                .NotNull().WithMessage("{PropertyName} must be present");

            RuleFor(a => a.Username)
                .NotNull().WithMessage("Please enter {PropertyName}")
                .NotEmpty().WithMessage("Please enter {PropertyName}");

            RuleFor(a => a.FirstName)
                .NotNull().WithMessage("Please enter {PropertyName}")
                .NotEmpty().WithMessage("Please enter {PropertyName}");

            RuleFor(a => a.MiddleName)
                .NotNull().WithMessage("Please enter {PropertyName}")
                .NotEmpty().WithMessage("Please enter {PropertyName}");

            RuleFor(a => a.LastName)
                .NotNull().WithMessage("Please enter {PropertyName}")
                .NotEmpty().WithMessage("Please enter {PropertyName}");

            RuleFor(a => a.BirthPlace)
                .NotNull().WithMessage("Please enter {PropertyName}")
                .NotEmpty().WithMessage("Please enter {PropertyName}");

            RuleFor(a => a.Country)
                .NotNull().WithMessage("Please enter {PropertyName}")
                .NotEmpty().WithMessage("Please enter {PropertyName}");

            RuleFor(a => a.Address)
                .NotNull().WithMessage("Please enter {PropertyName}")
                .NotEmpty().WithMessage("Please enter {PropertyName}");

            RuleFor(a => a.IdCard)
                .NotNull().WithMessage("Please enter {PropertyName}")
                .NotEmpty().WithMessage("Please enter {PropertyName}")
                .Length(9).WithMessage("Invalid {PropertyName}");

            RuleFor(a => a.CardAuthority)
                .NotNull().WithMessage("Please enter {PropertyName}")
                .NotEmpty().WithMessage("Please enter {PropertyName}");

            RuleFor(a => a.IBAN)
                .NotNull().WithMessage("Please enter {PropertyName}")
                .NotEmpty().WithMessage("Please enter {PropertyName}")
                .MaximumLength(34).WithMessage("Invalid {PropertyName}");

            RuleFor(a => a.StartDate)
                .NotNull().WithMessage("Please enter {PropertyName}")
                .NotEmpty().WithMessage("Please enter {PropertyName}");

            RuleFor(a => a.VacationHours)
                .NotNull().WithMessage("Please enter {PropertyName}")
                .NotEmpty().WithMessage("Please enter {PropertyName}");

            RuleFor(a => a.Office)
                .NotNull().WithMessage("Please enter {PropertyName}")
                .NotEmpty().WithMessage("Please enter {PropertyName}");

            RuleFor(a => a.Discipline)
                .NotNull().WithMessage("Please enter {PropertyName}")
                .NotEmpty().WithMessage("Please enter {PropertyName}");
        }
    }
}
