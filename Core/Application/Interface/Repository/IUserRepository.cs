using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Real_Estate.Core.Domain.Entities;

namespace Real_Estate.Core.Application.Interface.Repository
{
   public interface IUserRepository:IBaseRepository<User>
    {
        Task<User> Get(string id);
        Task<Manager> GetById(string id);
        Task<User> Get(Expression<Func<User, bool>> predicate);
        Task<ICollection<User>> GetAll();
    }
}