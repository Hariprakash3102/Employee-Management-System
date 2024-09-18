using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis; 

namespace Employee.Domain.Models
{
    public class EmployeeModel
    {
        [Key, Display(Name = "Employee Id")]
        public Guid EmployeeId { get; set; }

        [NotNull, Display(Name = "Full Name"), Required]
        public string? EmployeeName { get; set; }

        [Display(Name = "Email Address"), EmailAddress, Required]
        public string? EmployeeEmail { get; set; }

        [NotNull, Display(Name = "Phone Number"), Required]
        public string? EmployeePhone { get; set; }

        [NotNull, Display(Name = "Position"), Required]
        public string? EmployeePosition { get; set; }
    }
}
