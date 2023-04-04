using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Time_Tracking.DAL.Entities.Models;

namespace Time_Tracking.BLL.Repository.Base
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected Time_Tracking_DbContext Time_Tracking_DbContext;
        public RepositoryBase(Time_Tracking_DbContext time_Tracking_DbContext)
        => Time_Tracking_DbContext = time_Tracking_DbContext;
        public IQueryable<T> FindAll(bool trackChanges) => !trackChanges ? Time_Tracking_DbContext.Set<T>().AsNoTracking() : Time_Tracking_DbContext.Set<T>();
        /*public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) => !trackChanges ? Time_Tracking_DbContext.Set<T>().Where(expression).AsNoTracking() : Time_Tracking_DbContext.Set<T>().Where(expression);
 */

        public virtual IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges = false)
        {
            return trackChanges ? Time_Tracking_DbContext.Set<T>().Where(expression)
                                : Time_Tracking_DbContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity) => Time_Tracking_DbContext.Set<T>().Add(entity);
        public void Update(T entity) => Time_Tracking_DbContext.Set<T>().Update(entity);
        public void Delete(T entity) => Time_Tracking_DbContext.Set<T>().Remove(entity);
    }
}
