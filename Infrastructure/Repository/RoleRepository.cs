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
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(EstateDbContext context)
        {
            _context = context;
        }
        public async Task<Role> Get(string id)
        {
          var role = await _context.Roles
          .SingleOrDefaultAsync(a => a.Id == id && a.IsDeleted == false);
          return role;
        }

        public async Task<Role> Get(Expression<Func<Role, bool>> predicate)
        {
            var role = await _context.Roles
            .SingleOrDefaultAsync(predicate);
            return role;
        }

        public async Task<ICollection<Role>> GetAll()
        {
            return await _context.Roles
            .Where(a => a.IsDeleted == false)
            .ToListAsync();
        }
    }
}