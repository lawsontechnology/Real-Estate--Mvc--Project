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
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        
        public AddressRepository(EstateDbContext context)
        {
            _context = context;
        }
        public async Task<Address> Get(string id)
        {
            var address = await _context.Addresses
            .Include(x => x.Profile)
            .SingleOrDefaultAsync(a => a.Id == id && a.IsDeleted == false);
            return address;
        }

        public async Task<Address> Get(Expression<Func<Address, bool>> predicate)
        {
            var address = await _context.Addresses
            .Include(x => x.Profile)
            .SingleOrDefaultAsync(predicate);
            return address;
        }

        public async Task<ICollection<Address>> GetAll()
        {
              return await _context.Addresses
            .Include(x =>x.Profile)
            .Where(a => a.IsDeleted == false)
            .ToListAsync();  
        }
    }
}