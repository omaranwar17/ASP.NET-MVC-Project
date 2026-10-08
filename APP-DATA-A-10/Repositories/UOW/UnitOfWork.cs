using APP_DATA_A_10.Date.Contexts;
using APP_DATA_A_10.Repositories.Depatment;
using APP_DATA_A_10.Repositories.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_DATA_A_10.Repositories.UOW
{
     public class UnitOfWork : IUnitOfWork
    {
        private Lazy<IEmployeeRepositry> _employeeRepositry;
        private Lazy<IDepartmentRepositorie> _departmentRepository;
        private readonly APPDbContext _dbContext;
        public UnitOfWork( APPDbContext dbContext)
        {
            _employeeRepositry = new Lazy<IEmployeeRepositry>(() => new EmployeeRepositry(_dbContext));
            _departmentRepository = new Lazy<IDepartmentRepositorie>(() => new DepartmentRepositorie(_dbContext));
            _dbContext = dbContext;
        }
        public IEmployeeRepositry EmployeeRepositry => _employeeRepositry.Value;

        public IDepartmentRepositorie DepartmentRepository => _departmentRepository.Value;

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }
    }
}
