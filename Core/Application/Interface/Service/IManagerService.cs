using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Real_Estate.Core.Application.Dto;

namespace Real_Estate.Core.Application.Interface.Service
{
    public interface IManagerService
    {
        Task<BaseResponse<ManagerDto>> Register(ManagerRequestMode model);
        // Task<BaseResponse<ManagerDto>> Get(string id);
        Task<BaseResponse<ManagerDto>> Get(string staffNumber);
        Task<BaseResponse<ICollection<ManagerDto>>> GetAll();
        Task <BaseResponse<ManagerDto>> Delete(string ManagerId);
    }
}