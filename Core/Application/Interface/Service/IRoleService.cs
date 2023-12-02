using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Real_Estate.Core.Application.Dto;

namespace Real_Estate.Core.Application.Interface.Service
{
    public interface IRoleService
    {
        Task<BaseResponse<RoleDto>> Register(RoleRequestMode model);
        Task<BaseResponse<ICollection<RoleDto>>> GetAll();
    }
}