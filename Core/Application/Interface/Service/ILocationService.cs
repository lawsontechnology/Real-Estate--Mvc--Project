using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Real_Estate.Core.Application.Dto;

namespace Real_Estate.Core.Application.Interface.Service
{
    public interface ILocationService
    {
        Task<BaseResponse<LocationDto>> GetById(string id);
        Task<BaseResponse<LocationDto>> Get (string State);
        Task<BaseResponse<LocationDto>> RemoveLocation (string id);
        Task <BaseResponse<LocationDto>> Delete(string LocationId);
        Task<BaseResponse<ICollection<LocationDto>>> GetAll();
    }
}