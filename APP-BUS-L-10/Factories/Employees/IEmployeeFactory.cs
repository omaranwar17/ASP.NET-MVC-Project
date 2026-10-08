using APP_DATA_A_10.Models.Employees;
using APP_DATA_A_10.Services.Employees.Dtos;

namespace APP_DATA_A_10.Services.Employees.Factories
{
    public interface IEmployeeFactory
    {
        // Entity → DTO
        EmployeeDto ToDto(Employee employee);
        EmployeeDetailsDto ToDetailsDto(Employee employee);
        IEnumerable<EmployeeDto> ToDtoList(IEnumerable<Employee> employees);

        // DTO → Entity
        Employee ToEntity(CreateEmployeeDto dto);
        void UpdateEntity(Employee employee, UpdateEmployeeDto dto);
    }
}