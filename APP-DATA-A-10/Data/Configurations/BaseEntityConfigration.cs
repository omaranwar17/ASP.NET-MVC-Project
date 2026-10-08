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
    internal class BaseEntityConfigration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {

        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property((d) => d.CreatedOn).HasDefaultValueSql("GetDate()");
            builder.Property((d) => d.LastMidifiedOn).HasComputedColumnSql("GetDate()");
            //throw new NotImplementedException();
        }
    }
}
