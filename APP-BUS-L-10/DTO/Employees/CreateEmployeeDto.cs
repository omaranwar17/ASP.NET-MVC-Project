using APP_DATA_A_10.Models.Employees;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace APP_DATA_A_10.Services.Employees.Dtos
{
    public class CreateEmployeeDto
    {
        [Required]
        [MaxLength(50 , ErrorMessage = "name is max length 50 char")]
        [MinLength(3 , ErrorMessage = "name is mix length 3 char")]
        public string Name { get; set; } = null!;

        [Range(18, 65, ErrorMessage = "Age must be between 18 and 65")]
        public int? Age { get; set; }
        public string? Address { get; set; }
        public bool IsActive { get; set; }
        public decimal Salary { get; set; }
        public string? Email { get; set; } 
        public string? PhoneNumber { get; set; }
        public DateTime HiringDate { get; set; }
        public Gender Gender { get; set; }
        public EmployeeType EmployeeType { get; set; }
        public int CreatedBy { get; set; }   // مطلوب من الـ task
        [Display(Name = "Department")]
        public int? DepartmentId { get; set; }
        public IFormFile? Image { get; set; }
    }
}