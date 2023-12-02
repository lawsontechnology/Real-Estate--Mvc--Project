using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Real_Estate.Core.Domain.Entities;

namespace Real_Estate.Core.Application.Interface.Repository
{
    public interface ICustomerRepository:IBaseRepository<Customer>
    {
        Task<Customer> Get(string id);
        Task<Customer> Get(Expression<Func<Customer, bool>> predicate);
        Task<ICollection<Customer>> GetAll();
        Task Delete(string Id);
    }
}