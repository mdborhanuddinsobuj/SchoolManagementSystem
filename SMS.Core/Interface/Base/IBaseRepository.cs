using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using SMS.Core.Models.Base;

namespace SMS.Core.Interface.Base
{
    public interface IBaseRepository<T> where T:BaseModel
    {
        IQueryable<T> All();
        IQueryable<T> All(params Expression<Func<T, Object>>[] includeProperties);
        T Find(long id);
        T Find(Int64 id, params Expression<Func<T, Object>>[] includeProperties);
        void Insert(T entity);
        void Update(T entity, int id);
        void Delete(T entity);
    }
}
