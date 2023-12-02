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
    public class LocationRepository : BaseRepository<Location>, ILocationRepository
    {
        public LocationRepository(EstateDbContext context)
        {
            _context = context;
        }
        public async Task<Location> Get(string id)
        {
            var location = await _context.Locations
            .SingleOrDefaultAsync(a => a.Id == id && a.IsDeleted == false);
            return location;
        }
        public async Task Delete(string Id)
        {
            var entity = await _context.Locations.FindAsync(Id);

            if (entity != null)
            {
                entity.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Location> Get(Expression<Func<Location, bool>> predicate)
        {
            var location = await _context.Locations
            .SingleOrDefaultAsync(predicate);
            return location;
        }

        public async Task<ICollection<Location>> GetAll()
        {
            return await _context.Locations
            .Where(a => a.IsDeleted == false)
            .ToListAsync();
        }
    }
}