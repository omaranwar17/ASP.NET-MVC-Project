using APP_DATA_A_10.Models.Employees;
using APP_DATA_A_10.Repositories.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_DATA_A_10.Repositories.Employees
{
    public interface IEmployeeRepositry : IGenericRepository<Employee>
    {
      
    }
}
