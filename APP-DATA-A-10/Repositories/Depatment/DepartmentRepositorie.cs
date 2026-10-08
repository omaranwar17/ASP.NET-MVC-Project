using APP_DATA_A_10.Date.Contexts;
using APP_DATA_A_10.Models.Depatments;
using APP_DATA_A_10.Repositories.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_DATA_A_10.Repositories.Depatment
{
    public class DepartmentRepositorie : GenericRepository<Department> ,  IDepartmentRepositorie
    {
        private readonly APPDbContext _aPPDbContext;
        public DepartmentRepositorie(APPDbContext aPPDbContext):base(aPPDbContext)
        {
            _aPPDbContext = aPPDbContext;

        }
     
    }
}
