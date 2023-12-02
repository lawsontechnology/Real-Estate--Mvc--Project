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
    public class PhoneRepository : BaseRepository<Phone>, IPhoneRepository
    {
        public PhoneRepository(EstateDbContext context)
        {
            _context = context;
        }
        public async Task<Phone> Get(string id)
        {
            var phone = await _context.Phones
            .SingleOrDefaultAsync(a => a.Id == id && a.IsDeleted == false);
            return phone;
        }

        public async Task<Phone> Get(Expression<Func<Phone, bool>> predicate)
        {
            var phone = await _context.Phones
            .SingleOrDefaultAsync(predicate);
            return phone;
        }

        public async Task<ICollection<Phone>> GetAll()
        {
            return await _context.Phones
            .Where(a => a.IsDeleted == false)
            .ToListAsync();
        }
    }
}