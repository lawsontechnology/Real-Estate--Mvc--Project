using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Real_Estate.Core.Domain.Entities;

namespace Real_Estate.Core.Application.Interface.Repository
{
    public interface IManagerRepository:IBaseRepository<Manager>
    {
        Task<Manager> Get(string id);
        Task<Manager> Get(Expression<Func<Manager, bool>> predicate);
        Task<ICollection<Manager>> GetAll();
        Task Delete(string managerId);
    }
}