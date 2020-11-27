using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VincitWebApplication.Domain.Repositories;
using VincitWebApplication.Persistence.Contexts;

namespace VincitWebApplication.Persistence.Repositories
{
    /// <summary>
    /// Generic base repository class with basic CRUD functions implemented 
    /// </summary>
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected iot_dbContext Context { get; set; }
        public BaseRepository(iot_dbContext repositoryContext)
        {
            Context = repositoryContext;
        }
        public IQueryable<T> FindAll()
        {
            return Context.Set<T>().AsNoTracking();
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return Context.Set<T>().Where(expression).AsNoTracking();
        }
        public void Create(T entity)
        {
            Context.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            Context.Set<T>().Update(entity);
        }
        public void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
        }
    }
}
