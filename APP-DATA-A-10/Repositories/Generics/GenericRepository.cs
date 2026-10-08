using APP_DATA_A_10.Date.Contexts;
using APP_DATA_A_10.Models.Depatments;
using APP_DATA_A_10.Models.Employees;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace APP_DATA_A_10.Repositories.Generics
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly APPDbContext _aPPDbContext;
        public GenericRepository(APPDbContext dbContext)
        {

            _aPPDbContext = dbContext;            
        }

        public IEnumerable<TEntity> getAll(Expression<Func<TEntity, bool>> expression)
        {
            return _aPPDbContext.Set<TEntity>().Where(expression).ToList();
        }

        //public IEnumerable<TResult> getAll<TResult>(Expression<Func<TEntity, TResult>> expression)
        //{
        //    return _aPPDbContext.Set<TEntity>().Where((t) => t.IsDeleted != true).Select(expression);
        //}

        //getAll
        public IEnumerable<TEntity> getAll(bool withTracking = false)
        {
            if (withTracking)
            {
                return _aPPDbContext.Set<TEntity>().Where((t)=> t.IsDeleted != true).ToList();
            }
            else
            {
                return _aPPDbContext.Set<TEntity>().Where((t) => t.IsDeleted != true).AsNoTracking().ToList();
            }

        }


        //getId
        public TEntity? getDepatId(int id)
        {
            var dep = _aPPDbContext.Set<TEntity>().Find(id);
            return dep;

        }

        //add
        public void Add(TEntity entity)
        {
            _aPPDbContext.Set<TEntity>().Add(entity);
            //var result = _aPPDbContext.SaveChanges();
            //return result;

        }


        //update
        public void Update(TEntity entity)
        {
            _aPPDbContext.Set<TEntity>().Update(entity);
            //var result = _aPPDbContext.SaveChanges();
            //return result;

        }


        //remove
        public void Remove(TEntity entity)
        {
            _aPPDbContext.Set<TEntity>().Remove(entity);
            //return _aPPDbContext.SaveChanges();


        }

      
    }
}
