using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Real_Estate.Core.Application.Dto;
using Real_Estate.Core.Application.Interface.Repository;
using Real_Estate.Core.Application.Interface.Service;
using Real_Estate.Core.Domain.Entities;

namespace Real_Estate.Core.Application.Implementation
{
    public class CompanyService : ICompanyService
    {
         private readonly ICompanyRepository _company;
         public CompanyService(ICompanyRepository company)
         {
            _company = company;
         }

        public async Task<BaseResponse<CompanyDto>> Register(CompanyRequestMode model)
        {
            var company = await _company.Get(x => x.Name == model.Name);
            if (company != null)
            {
                return new BaseResponse<CompanyDto>
                {
                    Status = false,
                    Message = "company Already exist",
                };
            }
            Manager manager = new (); 
            var companys = new Company
            {
                Name = model.Name,
                CACRegNumber = model.CACRegNumber,
                Logo = model.Logo,
                Address = model.Address,
                DateCreated = DateTime.Now,
            };
             
             await _company.CreateAsync(companys);
             await _company.SaveAsync();
             return new BaseResponse<CompanyDto>
             {
                Status = true,
                Message = "Successful",
                Data = new CompanyDto
                {
                    Id = companys.Id,
                    Name = companys.Name,
                    CACRegNumber = companys.CACRegNumber,
                    Logo = companys.Logo,
                    Address = companys.Address,
                    ManagerId = manager.Id,
                }
             };
              
        }
    }
}