using APP_DATA_A_10.Models.Depatments;
using APP_DATA_A_10.Models.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace APP_DATA_A_10.Repositories.Generics
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {

        void Add(TEntity entity);
        IEnumerable<TEntity> getAll(bool withTracking = false);
        IEnumerable<TEntity> getAll(Expression<Func<TEntity, bool>> expression);
        TEntity? getDepatId(int id);
        void Remove(TEntity entity);
        void Update(TEntity entity);
      
    }
}
