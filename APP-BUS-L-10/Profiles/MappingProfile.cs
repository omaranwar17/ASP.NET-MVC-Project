using APP_DATA_A_10.Models.Employees;
using APP_DATA_A_10.Services.Employees.Dtos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_BUS_L_10.Profiles
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {

            CreateMap<Employee, EmployeeDto>()
            .ForMember(option => option.EmpGender, dec => dec.MapFrom(sce => sce.Gender))
            .ForMember(option => option.EmpType, dec => dec.MapFrom(sce => sce.EmployeeType))
            .ForMember(option => option.DepartmentName,
               dec => dec.MapFrom(sce => sce.DepartmentId == null ? "NO DEPAT" : sce.Departments.Name));
                                         



            //CreateMap<Employee, EmployeeDto>().ForMember(option => option.EmpType, dec => dec.MapFrom(sce => sce.EmployeeType)).ReverseMap();

            CreateMap<Employee , EmployeeDetailsDto>().ForMember(option => option.DepartmentName,
               dec => dec.MapFrom(sce => sce.Departments == null ? "NO DEPAT" : sce.Departments.Name));

      

            CreateMap<CreateEmployeeDto, Employee>();
            CreateMap<UpdateEmployeeDto, Employee>();
        }
    }
}
