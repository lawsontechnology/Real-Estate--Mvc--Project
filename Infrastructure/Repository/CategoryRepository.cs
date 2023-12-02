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
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(EstateDbContext context)
        {
            _context = context;
        }

        public async Task Delete(string Id)
        {
            var entity = await _context.Categories.FindAsync(Id);

            if (entity != null)
            {
                entity.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Category> Get(string id)
        {
            var categories = await _context.Categories
            .Include(x => x.Products)
            .Include(x => x.Locations)
            .SingleOrDefaultAsync(a => a.Id == id && a.IsDeleted == false);
            return categories;
        }

        public async Task<Category> Get(Expression<Func<Category, bool>> predicate)
        {
           var categories = await _context.Categories
           .Include(x => x.Products)
           .Include(x => x.Locations)
           .SingleOrDefaultAsync(predicate);
            return categories;
        }

        public async Task<ICollection<Category>> GetAll()
        {
           return await _context.Categories
           .Include(x => x.Products)
           .Include(x => x.Locations)
           .Where(a => a.IsDeleted == false)
            .ToListAsync();
        }
    }
}