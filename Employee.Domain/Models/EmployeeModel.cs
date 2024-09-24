using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis; 

namespace Employee.Domain.Models;

    public class EmployeeModel
    {
        [Display(Name = "Employee Id"),Key]
        public Guid EmployeeId { get; set; }

        [Display(Name = "Full Name")]
        public string? EmployeeName { get; set; }

        [Display(Name = "Email Address")]
        public string? EmployeeEmail { get; set; }

        [Display(Name = "Phone Number")]
        public string? EmployeePhone { get; set; }

        [Display(Name = "Position")]
        public string? EmployeePosition { get; set; }
    }

