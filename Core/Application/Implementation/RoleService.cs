using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Real_Estate.Core.Application.Dto;
using Real_Estate.Core.Application.Interface.Repository;
using Real_Estate.Core.Application.Interface.Service;
using Real_Estate.Core.Domain.Entities;

namespace Real_Estate.Core.Application.Implementation
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _role;
        public RoleService(IRoleRepository role)
        {
            _role = role;
        }

        public async Task<BaseResponse<ICollection<RoleDto>>> GetAll()
        {
            List<RoleDto> listOfRole = new List<RoleDto>();
            var rol = await _role.GetAll();
            foreach (var roles in rol)
            {
                var role = new RoleDto{

                    Id = roles.Id,
                    Name = roles.Name,
                    Description = roles.Description,
                };
                listOfRole.Add(role);
            }

            return new BaseResponse<ICollection<RoleDto>>
            {
                    Status = true,
                    Message = "List of Role",
                    Data = listOfRole,
            };
        }

        public async Task<BaseResponse<RoleDto>> Register(RoleRequestMode model)
        {
            var role = await _role.Get(x => x.Name == model.Name);
            if (role != null)
            {
                return new BaseResponse<RoleDto>
                {
                    Status = false,
                    Message = "Role With This Name Already exist",

                };
            }
             
             Role roles = new()
             {
               Name = model.Name,
               Description = model.Description,
               DateCreated = DateTime.Now,
             };
             await _role.CreateAsync(roles);
             await _role.SaveAsync();
            return new BaseResponse<RoleDto>
            {
                Status = true,
                Message = "Sucessfull",
                Data = new RoleDto
                {
                    Id = roles.Id,
                    Name = roles.Name,
                }
            };
        }
    }
}