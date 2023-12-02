using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Real_Estate.Core.Domain.Entities;

namespace Real_Estate.Core.Application.Interface.Repository
{
    public interface IPhoneRepository : IBaseRepository<Phone>
    {
        Task<Phone> Get(string id);
        Task<Phone> Get(Expression<Func<Phone, bool>> predicate);
        Task<ICollection<Phone>> GetAll();
    }
}