using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Real_Estate.Core.Domain.Entities;

namespace Real_Estate.Core.Application.Interface.Repository
{
    public interface IAddressRepository : IBaseRepository<Address>
    {
        Task<Address> Get(string id);
        Task<Address> Get(Expression<Func<Address, bool>> predicate);
        Task<ICollection<Address>> GetAll();
    }
}