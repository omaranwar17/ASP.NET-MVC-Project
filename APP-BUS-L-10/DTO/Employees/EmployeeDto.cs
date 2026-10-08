using APP_DATA_A_10.Models.Employees;
using System.ComponentModel.DataAnnotations;

namespace APP_DATA_A_10.Services.Employees.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? Age { get; set; }
        public bool IsActive { get; set; }
        public decimal Salary { get; set; }
        public string Email { get; set; } = null!;
        public string? EmpGender { get; set; } 
        public string? EmpType { get; set; }
        [Display(Name = "Department")]
        public string? DepartmentName { get; set; }
    }
}