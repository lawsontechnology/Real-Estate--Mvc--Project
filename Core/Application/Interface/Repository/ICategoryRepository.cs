using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Real_Estate.Core.Domain.Entities;

namespace Real_Estate.Core.Application.Interface.Repository
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<Category> Get(string id);
        Task<Category> Get(Expression<Func<Category, bool>> predicate);
        Task<ICollection<Category>> GetAll();
        Task Delete(string Id);
    }
}