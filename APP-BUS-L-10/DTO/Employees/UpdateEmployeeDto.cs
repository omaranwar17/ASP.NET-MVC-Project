using APP_DATA_A_10.Models.Employees;
using Microsoft.AspNetCore.Http;

namespace APP_DATA_A_10.Services.Employees.Dtos
{
    public class UpdateEmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? Age { get; set; }
        public string Address { get; set; } = null!;
        public bool IsActive { get; set; }
        public decimal Salary { get; set; }
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public DateTime HiringDate { get; set; }
        public Gender Gender { get; set; }
        public EmployeeType EmployeeType { get; set; }
        public int LastModifiedBy { get; set; }   // مطلوب من الـ task
        public int? DepartmentId { get; set; }
        public IFormFile? Image { get; set; }

    }
}