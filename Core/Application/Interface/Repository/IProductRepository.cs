using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Real_Estate.Core.Domain.Entities;

namespace Real_Estate.Core.Application.Interface.Repository
{
    public interface IProductRepository: IBaseRepository<Product>
    {
        Task<Product> Get(string id);
        Task<Product> Get(Expression<Func<Product, bool>> predicate);
        Task<ICollection<Product>> GetAll();
        Task Delete(string Id);
    }
}