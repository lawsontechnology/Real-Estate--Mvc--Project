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
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(EstateDbContext context)
        {
            _context = context;
        }
        public async Task<Product> Get(string id)
        {
            var product = await _context.Products
            .Include(x => x.Locations)
            .SingleOrDefaultAsync(a => a.Id == id && a.IsDeleted == false);
            return product;
        }

        public async Task Delete(string Id)
        {
            var entity = await _context.Products.FindAsync(Id);

            if (entity != null)
            {
                entity.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }
        public async Task<Product> Get(Expression<Func<Product, bool>> predicate)
        {
            var product = await _context.Products
            .Include(x => x.Locations)
            .SingleOrDefaultAsync(predicate);
            return product;
        }

        public async Task<ICollection<Product>> GetAll()
        {
            return await _context.Products
            .Include( x =>x.Locations)
            .Where(a => a.IsDeleted == false)
            .ToListAsync();
        }
    }
}