using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Real_Estate.Core.Domain.Entities;

namespace Real_Estate.Core.Application.Interface.Repository
{
    public interface IRoleRepository:IBaseRepository<Role>
    {
        Task<Role> Get(string id);
        Task<Role> Get(Expression<Func<Role, bool>> predicate);
        Task<ICollection<Role>> GetAll();
    }
}