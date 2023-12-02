using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Real_Estate.Core.Application.Interface.Repository;
using Real_Estate.Core.Domain.Entities;
using Real_Estate.Infrastructure.Context;

namespace Real_Estate.Infrastructure.Repository
{
    public class WalletRepository : BaseRepository<Wallet>, IWalletRepository
    {
        public WalletRepository(EstateDbContext context)
        {
            _context = context;
        }
        public async Task<Wallet> Get(string id)
        {
            var wallet = await _context.Wallets
            .SingleOrDefaultAsync(a => a.UserId == id && a.IsDeleted == false);
            return wallet;
        }

        public async Task<Wallet> Get(Expression<Func<Wallet, bool>> predicate)
        {
            var wallet = await _context.Wallets
            .SingleOrDefaultAsync(predicate);
            return wallet;
        }

        public async Task<ICollection<Wallet>> GetAll()
        {
            return await _context.Wallets
            .Where(a => a.IsDeleted == false)
            .ToListAsync();
        }
    }
}