using APP_BUS_L_10.DTO.Depatments;

namespace APP_BUS_L_10.Services.Departments
{
    public interface IDepartmentServices
    {
        int addDepart(AddDepartmentDbo add);
        bool deleteDepart(int id);
        IEnumerable<DepartmentDto> GetDepartments();
        DepartmentDetelesDto getDepatId(int id);
        int updateDepart(UpdateDepartment update);
    }
}