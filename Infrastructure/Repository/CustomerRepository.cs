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
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(EstateDbContext context)
        {
            _context = context;
        }
        public async Task<Customer> Get(string id)
        {
            var customer = await _context.Customers
            .SingleOrDefaultAsync(a => a.Id == id && a.IsDeleted == false);
            return customer;
        }

        public async Task Delete(string Id)
        {
            var entity = await _context.Customers.FindAsync(Id);

            if (entity != null)
            {
                entity.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Customer> Get(Expression<Func<Customer, bool>> predicate)
        {
            var customer = await _context.Customers
            .SingleOrDefaultAsync(predicate);
            return customer;
        }

        public async Task<ICollection<Customer>> GetAll()
        {
            return await _context.Customers
            .Where(a => a.IsDeleted == false)
            .ToListAsync();
        }
    }
}