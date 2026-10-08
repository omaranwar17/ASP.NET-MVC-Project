using APP_BUS_L_10.DTO.Depatments;
using APP_DATA_A_10.Models.Depatments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_BUS_L_10.Factories.Departments
{
    public static class DepartmentFactoriey
    {
        public static DepartmentDetelesDto toDepartmentDeteles(this Department department)
        {
            return new DepartmentDetelesDto() 
            {
                Id = department.Id,
                Name = department.Name,
                Code = department.Code,
                Description = department.Description,
                DataOfCreation = DateOnly.FromDateTime(department.CreatedOn),
                CreatedBy = department.CreatedBy,
                IsDeleted = department.IsDeleted,
                LastMidifiedBy = department.LastMidifiedBy,

            };
           

        }

        public static DepartmentDto toDepartmentDto(this Department department)
        {
            return new DepartmentDto()
            {
                Id = department.Id,
                Name = department.Name,
                Description = department.Description,
                Code = department.Code,
                DataOfCreation = DateOnly.FromDateTime(department.CreatedOn)
            };
        }

        public static Department toEntity(this AddDepartmentDbo addDepartment)
        {
            return new Department()
            {
                Name = addDepartment.Name,
                Description = addDepartment.Description,
                Code = addDepartment.Code,
                CreatedOn = addDepartment.DataOfCreation.ToDateTime(new TimeOnly())
            };
        }

        public static Department toEntity(this UpdateDepartment updateDepartment)
        {
            return new Department()
            {
                Id = updateDepartment.Id,
                Name = updateDepartment.Name,
                Code = updateDepartment.Code,
                Description = updateDepartment.Description,
                CreatedOn = updateDepartment.DataOfCreation.ToDateTime(new TimeOnly())

            };

        }
    }
}
