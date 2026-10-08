using APP_DATA_A_10.Data.Configurations;
using APP_DATA_A_10.Models.Depatments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_DATA_A_10.Date.Configurations
{
    internal class DepartmentConfiguration : BaseEntityConfigration<Department> ,IEntityTypeConfiguration<Department>
    {
        public new void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property((d) => d.Id).UseIdentityColumn(10,10);
            builder.Property((d) => d.Name).HasColumnType("varchar(30)");
            builder.Property((d) => d.Code).HasColumnType("varchar(30)");
            builder.HasMany((d)=> d.Employees).WithOne((e)=> e.Departments)
                   .HasForeignKey(e=>e.DepartmentId).OnDelete(DeleteBehavior.SetNull);
         
            base.Configure(builder);
            
        }
    }
}
