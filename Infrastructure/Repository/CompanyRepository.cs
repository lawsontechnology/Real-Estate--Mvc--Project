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
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(EstateDbContext context)
        {
            _context = context;
        }
        public async Task<Company> Get(string id)
        {
          var companies = await _context.Companies
          .SingleOrDefaultAsync(a => a.Id == id && a.IsDeleted == false);
          return companies;
        }

        public async Task<Company> Get(Expression<Func<Company, bool>> predicate)
        {
           var companies = await _context.Companies
           .SingleOrDefaultAsync(predicate);
           return companies;
        }

        public async Task<ICollection<Company>> GetAll()
        {
            return await _context.Companies
            .Where(a => a.IsDeleted == false)
            .ToListAsync();
        }
    }
}