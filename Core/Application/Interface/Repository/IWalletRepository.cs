using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Real_Estate.Core.Domain.Entities;

namespace Real_Estate.Core.Application.Interface.Repository
{
   public interface IWalletRepository:IBaseRepository<Wallet>
    {
        Task<Wallet> Get(string id);
        Task<Wallet> Get(Expression<Func<Wallet, bool>> predicate);
        Task<ICollection<Wallet>> GetAll();
    }
}