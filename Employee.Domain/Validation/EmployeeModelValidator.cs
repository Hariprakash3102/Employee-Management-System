using Employee.Domain.Models;
using FluentValidation; 

namespace Employee.Domain.Validation
{
    public class EmployeeModelValidator : AbstractValidator<EmployeeModel>
    {
        public EmployeeModelValidator()
        {
            RuleFor(emp => emp.EmployeeName)
                
                .NotEmpty().WithMessage("Employee Name is required.")
                .Length(2, 30).WithMessage("Employee name must be between 2 and 30 characters.")
                .Matches(@"^[a-zA-Z\s]+$").WithMessage("Employee name only have Alphabetics")
                .WithName("Full Name");

            RuleFor(emp => emp.EmployeeEmail)
                .EmailAddress().WithMessage("Enter the valid Email")
                .NotEmpty().WithMessage("Employee Email is requried")
                .Matches(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]{1,4}$").WithMessage("Email structure is not correct.");


            RuleFor(emp => emp.EmployeePosition)
                .NotEmpty().WithMessage("Employee Position is requried");

            RuleFor(emp => emp.EmployeePhone)
                .NotEmpty().WithMessage("Employee Email is requried"); 


        }

    }
}
