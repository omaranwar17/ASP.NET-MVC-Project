using APP_DATA_A_10.Models.Depatments;
using APP_DATA_A_10.Models.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_DATA_A_10.Data.Configurations
{
    internal class EmployeeConfiguration : BaseEntityConfigration<Employee> ,IEntityTypeConfiguration<Employee>
    {
        public new void Configure(EntityTypeBuilder<Employee> builder)
        {
            //builder.Property((e) => e.Id).UseIdentityColumn(10, 10);
            builder.Property((e) => e.Name).HasColumnType("varchar(50)");
            builder.Property(e => e.Salary).HasColumnType("decimal(10,2)");


            builder.Property((e) => e.Gender).HasConversion((g) => g.ToString(),(tg) => (Gender) Enum.Parse(typeof(Gender) , tg));
            builder.Property((e) => e.EmployeeType).HasConversion((E) => E.ToString(),(tE) => (EmployeeType) Enum.Parse(typeof(EmployeeType) , tE));
            //throw new NotImplementedException();
            base.Configure(builder);
        }
    }
}
