using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Real_Estate.Core.Domain.Entities;

namespace Real_Estate.Core.Application.Interface.Repository
{
   public interface ICompanyRepository:IBaseRepository<Company>
    {
        Task<Company> Get(string id);
        Task<Company> Get(Expression<Func<Company, bool>> predicate);
        Task<ICollection<Company>> GetAll();
    }
}