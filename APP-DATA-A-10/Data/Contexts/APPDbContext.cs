using APP_DATA_A_10.Models.Auth_User;
using APP_DATA_A_10.Models.Depatments;
using APP_DATA_A_10.Models.Employees;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace APP_DATA_A_10.Date.Contexts
{
    public class APPDbContext :IdentityDbContext<AppUser>
    {

        public APPDbContext(DbContextOptions<APPDbContext> options):base(options)
        {
            
        }

        public DbSet<Department> departments { get; set; }
        public DbSet<Employee> employees { get; set; }
     

      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);   // ✅ السطر الناقص
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
         
        }
    }
}
