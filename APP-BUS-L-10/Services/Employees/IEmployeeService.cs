using APP_DATA_A_10.Services.Employees.Dtos;

namespace APP_DATA_A_10.Services.Employees
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDto> GetAll(string? EmployeeSearchName);
        EmployeeDetailsDto? GetById(int id);
        int Add(CreateEmployeeDto dto);
        int Update(UpdateEmployeeDto dto);
        int  Delete(int id);   // مفيد حتى لو لم يُطلب صريحاً
    }
}