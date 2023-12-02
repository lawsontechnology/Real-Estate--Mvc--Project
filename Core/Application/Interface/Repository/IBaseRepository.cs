using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Real_Estate.Core.Application.Interface.Repository
{
    public interface IBaseRepository<T>
    {
        Task<T> CreateAsync(T entity);
        T Update(T entity);
        bool Check(Expression<Func<T, bool>> predicate);
        Task<int> SaveAsync();
        

        
    }
}