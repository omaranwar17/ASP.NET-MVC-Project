using APP_DATA_A_10.Repositories.Depatment;
using APP_DATA_A_10.Repositories.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_DATA_A_10.Repositories.UOW
{
    public interface IUnitOfWork
    {
        public IEmployeeRepositry EmployeeRepositry { get; }
        public IDepartmentRepositorie DepartmentRepository { get; }

        public int SaveChanges();
    }
}
