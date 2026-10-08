using APP_DATA_A_10.Models.Depatments;
using APP_DATA_A_10.Models.Employees;
using APP_DATA_A_10.Services.Employees.Dtos;

namespace APP_DATA_A_10.Services.Employees.Factories
{
    public class EmployeeFactory : IEmployeeFactory
    {
        // ============ Entity → DTO ============

        public EmployeeDto ToDto(Employee employee)
        {
            return new EmployeeDto
            {
                Id = employee.Id,
                Name = employee.Name,
                Age = employee.Age,
                IsActive = employee.IsActive,
                Salary = employee.Salary,
                Email = employee.Email,
                //Gender = employee.Gender.ToString(),
                //EmployeeType = employee.EmployeeType.ToString(),
            };
        }

        public EmployeeDetailsDto ToDetailsDto(Employee employee)
        {
            return new EmployeeDetailsDto
            {
                Id = employee.Id,
                Name = employee.Name,
                Age = employee.Age,
                Address = employee.Address,
                IsActive = employee.IsActive,
                Salary = employee.Salary,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                HiringDate = employee.HiringDate,
                Gender = employee.Gender,
                DepartmentId = employee.DepartmentId,
                EmployeeType = employee.EmployeeType,
                Image = employee.Image,
                DepartmentName = employee.Departments == null             
                            ? "No Department"
                            : employee.Departments.Name
            };
        }

        public IEnumerable<EmployeeDto> ToDtoList(IEnumerable<Employee> employees)
        {
            return employees.Select(ToDto);
        }

        // ============ DTO → Entity ============

        public Employee ToEntity(CreateEmployeeDto dto)
        {
            return new Employee
            {
                Name = dto.Name,
                Age = dto.Age,
                Address = dto.Address,
                IsActive = dto.IsActive,
                Salary = dto.Salary,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                HiringDate = dto.HiringDate,
                Gender = dto.Gender,
                EmployeeType = dto.EmployeeType,
                CreatedBy = dto.CreatedBy,
                DepartmentId = dto.DepartmentId,
                CreatedOn = DateTime.Now
            };
        }

        public void UpdateEntity(Employee employee, UpdateEmployeeDto dto)
        {
            employee.Name = dto.Name;
            employee.Age = dto.Age;
            employee.Address = dto.Address;
            employee.IsActive = dto.IsActive;
            employee.Salary = dto.Salary;
            employee.Email = dto.Email;
            employee.PhoneNumber = dto.PhoneNumber;
            employee.HiringDate = dto.HiringDate;
            employee.Gender = dto.Gender;
            employee.EmployeeType = dto.EmployeeType;
            employee.LastMidifiedBy = dto.LastModifiedBy;
            employee.LastMidifiedOn = DateTime.Now;
            employee.DepartmentId = dto.DepartmentId;
         
        }
    }
}