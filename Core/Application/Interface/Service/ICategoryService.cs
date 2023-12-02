using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Real_Estate.Core.Application.Dto;

namespace Real_Estate.Core.Application.Interface.Service
{
    public interface ICategoryService
    {
        Task<BaseResponse<CategoryDto>> GetByName(string Name);
        Task<BaseResponse<CategoryDto>> GetByPrice(double Price);
        Task <BaseResponse<CategoryDto>> Delete(string id);
        Task<BaseResponse<ICollection<CategoryDto>>> GetAll();
    }
}