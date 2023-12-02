using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Real_Estate.Core.Domain.Entities;

namespace Real_Estate.Core.Application.Interface.Repository
{
    public interface IProfileRepository:IBaseRepository<Profile>
    {
        Task<Profile> Get(string id);
        Task<Profile> Get(Expression<Func<Profile, bool>> predicate);
        Task<ICollection<Profile>> GetAll();
    }
}