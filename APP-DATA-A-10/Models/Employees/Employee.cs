using APP_DATA_A_10.Models.Depatments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_DATA_A_10.Models.Employees
{
    public class Employee :BaseEntity
    {
      
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int? Age { get; set; }
        public decimal Salary { get; set; }
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public DateTime HiringDate { get; set; }
        public Gender Gender { get; set; }
        public EmployeeType EmployeeType { get; set; }
        public bool IsActive { get; set; }
        public int? DepartmentId { get; set; }
        public virtual Department? Departments { get; set; }
        public string? Image { get; set; }


    }
}
