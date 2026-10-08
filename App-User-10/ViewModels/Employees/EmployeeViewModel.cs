using APP_DATA_A_10.Models.Employees;
using APP_DATA_A_10.Services.Employees.Dtos;
using System.ComponentModel.DataAnnotations;

namespace App_User_10.ViewModels.Employees
{
    public class EmployeeViewModel : CreateEmployeeDto
    {
        public int Id { get; set; }

        public int? LastModifiedBy { get; set; }
    }
}