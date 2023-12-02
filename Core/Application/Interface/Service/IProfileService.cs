using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Real_Estate.Core.Application.Dto;

namespace Real_Estate.Core.Application.Interface.Service
{
    public interface IProfileService
    {
        Task<BaseResponse<ProfileDto>> Register(ProfileRequestMode model);
        Task<BaseResponse<ICollection<ProfileDto>>> GetAll();
        Task<BaseResponse<ProfileDto>> GetById(string id);
        Task<BaseResponse<ProfileDto>> GetByEmail(string email);
    }
}