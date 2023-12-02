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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(EstateDbContext context)
        {
            _context = context;
        }
        public async Task<User> Get(string id)
        {
            var user = await _context.Users
            .Include(x => x.Wallet)
            .Include(x => x.Manager)
            .Include(x => x.Customer)
            .Include(x => x.Roles)
            .SingleOrDefaultAsync(a => a.Id == id && a.IsDeleted == false);
            return user;


        }

        public async Task<User> Get(Expression<Func<User, bool>> predicate)
        {

            var user = await _context.Users
            .Include(x => x.Wallet)
            .Include(x => x.Manager)
            .Include(x => x.Customer)
            .Include(x => x.Roles)
            .SingleOrDefaultAsync(predicate);
            return user;
        }

        public async Task<ICollection<User>> GetAll()
        {

            var users = await _context.Users
                .Include(x => x.Wallet)
                .Include(x => x.Manager)
                .Include(x => x.Customer)
                .Include(x => x.Roles)
                .Include(x => x.Profile)  
                .Where(x => !x.IsDeleted)
                .ToListAsync();

            return users;
        }

        public async Task<Manager> GetById(string id)
        {
            var user = await _context.Managers
            .FirstOrDefaultAsync(x => x.UserId == id);
            return user;
        }
    }
}