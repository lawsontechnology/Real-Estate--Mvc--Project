using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Real_Estate.Core.Domain.Entities;

namespace Real_Estate.Core.Application.Interface.Repository
{
    public interface ILocationRepository : IBaseRepository<Location>
    {
        Task<Location> Get(string id);
        Task<Location> Get(Expression<Func<Location, bool>> predicate);
        Task<ICollection<Location>> GetAll(); 
        Task Delete(string Id);
    }
}