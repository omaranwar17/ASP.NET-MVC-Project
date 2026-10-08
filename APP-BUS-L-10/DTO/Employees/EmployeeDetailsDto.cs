using APP_DATA_A_10.Models.Employees;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace APP_DATA_A_10.Services.Employees.Dtos
{
    public class EmployeeDetailsDto
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

        // 🆕 حقول Administration
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public int? DepartmentId { get; set; }
        [Display(Name = "Department")]
        public string? DepartmentName { get; set; }
        public string? Image { get; set; }
        public IFormFile? ImageName { get; set; }



    }
}