using APP_DATA_A_10.Date.Contexts;
using APP_DATA_A_10.Models.Depatments;
using APP_DATA_A_10.Models.Employees;
using APP_DATA_A_10.Repositories.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_DATA_A_10.Repositories.Employees
{
    public class EmployeeRepositry : GenericRepository<Employee> , IEmployeeRepositry
    {
        private readonly APPDbContext _aPPDbContext;
        public EmployeeRepositry(APPDbContext dbContext):base(dbContext)
        {
            _aPPDbContext = dbContext;
        }

      

    }
}
