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
    public class ManagerRepository : BaseRepository<Manager>, IManagerRepository
    {
         public ManagerRepository(EstateDbContext context)
         {
            _context = context;
         }

        public async Task Delete(string managerId)
        {
            var manager = await _context.Managers
            .FindAsync(managerId);
            manager.IsDeleted = true;
            
        }

        public async Task<Manager> Get(string id)
        {
             var manager = await _context.Managers
             .SingleOrDefaultAsync(a => a.Id == id && a.IsDeleted == false);
             return manager;
        }

        public async Task<Manager> Get(Expression<Func<Manager, bool>> predicate)
        {
            var manager = await _context.Managers
            .SingleOrDefaultAsync(predicate);
            return manager;
        }

        public async Task<ICollection<Manager>> GetAll()
        {
          var a= await _context.Managers
          .Where(a => a.IsDeleted == false)
          .ToListAsync();
          return a;
        }
    }
}