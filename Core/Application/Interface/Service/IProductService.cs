using Real_Estate.Core.Application.Dto;
using Real_Estate.Core.Domain.Entities;

namespace Real_Estate.Core.Application.Interface.Service
{
    public interface IProductService
    {
        Task<BaseResponse<ProductDto>> Register(ProductRequestMode model);
        Task<BaseResponse<ICollection<ProductDto>>> GetAll();
        Task <BaseResponse<ProductDto>> Delete(string ProductId);
        Task<BaseResponse<ProductDto>> Update(ProductUpdateModel model);
        Task<BaseResponse<ProductDto>> GetById(string id);
        Task<BaseResponse<ProductDto>> GetByName(string name);
        Task<BaseResponse<ProductDto>> PurchaseProduct(string id);
    }
}