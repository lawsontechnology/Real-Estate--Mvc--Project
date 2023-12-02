using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Real_Estate.Core.Application.Dto;

namespace Real_Estate.Core.Application.Interface.Service
{
    public interface IUserService
    {
        Task<BaseResponse<UserDto>> Login(LoginRequestModel model);
    }
}