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
    public class ProfileRepository : BaseRepository<Profile>, IProfileRepository
    {
        public ProfileRepository(EstateDbContext context)
        {
            _context = context;
        }
        public async Task<Profile> Get(string id)
        {
            var profile = await _context.Profiles
            .Include(x => x.Address)
            .Include(x => x.Phone)
            .Include(x => x.User)
            .SingleOrDefaultAsync(a => a.Id == id && a.IsDeleted == false);
            return profile;

        }

        public async Task<Profile> Get(Expression<Func<Profile, bool>> predicate)
        {
            var profile = await _context.Profiles
            .Include(x => x.Address)
            .Include(x => x.Phone)
            .Include(x => x.User)
            .SingleOrDefaultAsync(predicate);
            return profile;
        }

        public async Task<ICollection<Profile>> GetAll()
        {
            // var profile = await _context.Profiles
            // .Include(x =>x.Address)
            // .Include(x => x.Phone)
            // .Include(x => x.User)
            // .ThenInclude(x => x.UserRoles)
            // .ThenInclude(x => x.Role)
            // .Where(a => a.IsDeleted == false)
            // .ToListAsync();
            // return profile;

            var profiles = await _context.Profiles
                .Include(x => x.Address)
                .Include(x => x.Phone)
                .Include(x => x.User)
                .ThenInclude(x => x.Roles)
                .Where(a => a.IsDeleted == false)
                .ToListAsync();

            var nonNullProfiles = profiles.Where(p => p.Address != null && p.Phone != null && p.User != null).ToList();

            return nonNullProfiles;
        }
    }
}