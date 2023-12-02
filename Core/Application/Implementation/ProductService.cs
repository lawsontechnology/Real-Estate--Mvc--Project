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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _product;
        private readonly ICategoryRepository _category;
        private readonly ILocationRepository _location;
        private readonly IWalletRepository _wallet;
        public ProductService(IProductRepository product, ICategoryRepository category, ILocationRepository location, IWalletRepository wallet)
        {
            _product = product;
            _category = category;
            _location = location;
            _wallet = wallet;
        }

        public async Task<BaseResponse<ProductDto>> Delete(string ProductId)
        {
            var product = await _product.Get(ProductId);
            var category = await _category.Get(product.CategoryId);
            if (product == null)
            {
                return new BaseResponse<ProductDto>
                {
                    Status = false,
                    Message = "Product Not Found",
                };
            }
            await _product.Delete(ProductId);
            _product.Update(product);
            await _product.SaveAsync();
            return new BaseResponse<ProductDto>
            {
                Message = "Successful Deleted",
                Status = true,
                Data = new ProductDto
                {
                    Id = product.Id,
                    CategoryId = category.Id,
                    Condition = product.Condition,
                    Name = product.Name,
                    Price = product.Price,
                    ProductCode = product.ProductCode,
                    Type = product.Type,
                    SquareFeet = product.SquareFeet,
                    SquareMeter = product.SquareMeter,
                    ProductImage = product.ProductImage,
                    Locations = product.Locations.Select(x => new LocationDto
                    {
                        City = x.City,
                        Country = x.Country,
                        Number = x.Number,
                        State = x.State,
                        Street = x.Street,
                    }).ToList(),
                }
            };
        }

        public async Task<BaseResponse<ICollection<ProductDto>>> GetAll()
        {
            List<ProductDto> listOfProduct = new List<ProductDto>();
            var product = await _product.GetAll();
            foreach (var products in product)
            {
                var category = await _category.Get(products.CategoryId);
                var productList = new ProductDto
                {
                    Id = products.Id,
                    CategoryId = $"{category.Id}, {category.Price}, {category.Name}",
                    Condition = products.Condition,
                    Name = products.Name,
                    Price = products.Price,
                    ProductCode = products.ProductCode,
                    Type = products.Type,
                    SquareFeet = products.SquareFeet,
                    SquareMeter = products.SquareMeter,
                    ProductImage = products.ProductImage,
                    Locations = products.Locations.Select(x => new LocationDto
                    {
                        City = x.City,
                        Country = x.Country,
                        Number = x.Number,
                        State = x.State,
                        Street = x.Street,
                    }).ToList(),
                };
                listOfProduct.Add(productList);
            }
            return new BaseResponse<ICollection<ProductDto>>
            {
                Status = true,
                Message = "successful",
                Data = listOfProduct,
            };
        }

        public async Task<BaseResponse<ProductDto>> GetById(string id)
        {
            var products = await _product.Get(id);
            var category = await _category.Get(products.CategoryId);
            if (products == null)
            {
                return new BaseResponse<ProductDto>
                {
                    Status = false,
                    Message = "Data No Found",
                };
            }
            return new BaseResponse<ProductDto>
            {
                Status = true,
                Message = "Data found ",
                Data = new ProductDto
                {
                    Id = products.Id,
                    CategoryId = category.Id,
                    Condition = products.Condition,
                    Name = products.Name,
                    Price = products.Price,
                    ProductCode = products.ProductCode,
                    Type = products.Type,
                    SquareFeet = products.SquareFeet,
                    SquareMeter = products.SquareMeter,
                    ProductImage = products.ProductImage,
                    Locations = products.Locations.Select(x => new LocationDto
                    {
                        City = x.City,
                        Country = x.Country,
                        Number = x.Number,
                        State = x.State,
                        Street = x.Street,
                    }).ToList(),
                }
            };
        }

        public async Task<BaseResponse<ProductDto>> GetByName(string name)
        {
            var products = await _product.Get(x => x.Name == name);
            var category = await _category.Get(products.CategoryId);
            if (products == null)
            {
                return new BaseResponse<ProductDto>
                {
                    Status = false,
                    Message = "Data No Found",
                };
            }
            return new BaseResponse<ProductDto>
            {
                Status = true,
                Message = "Data found ",
                Data = new ProductDto
                {
                    Id = products.Id,
                    CategoryId = category.Id,
                    Condition = products.Condition,
                    Name = products.Name,
                    Price = products.Price,
                    ProductCode = products.ProductCode,
                    Type = products.Type,
                    SquareFeet = products.SquareFeet,
                    SquareMeter = products.SquareMeter,
                    ProductImage = products.ProductImage,
                    Locations = products.Locations.Select(x => new LocationDto
                    {
                        City = x.City,
                        Country = x.Country,
                        Number = x.Number,
                        State = x.State,
                        Street = x.Street,
                    }).ToList(),
                }
            };
        }


        public async Task<BaseResponse<ProductDto>> PurchaseProduct(string id)
        {
            var products = await _product.Get(id);

            if (products.Locations.Any())
            {
                var firstLocation = products.Locations.First();

                var locationDto = new LocationDto
                {
                    City = firstLocation.City,
                    Country = firstLocation.Country,
                    Number = firstLocation.Number,
                    Id = firstLocation.Id,
                    IsDeleted = firstLocation.IsDeleted,
                    State = firstLocation.State,
                    Street = firstLocation.Street,
                };

                var locationId = locationDto.Id;
                var foundLocation = await _location.Get(locationId);
                var category = await _category.Get(products.CategoryId);

                if (foundLocation != null)
                {
                    foundLocation.IsDeleted = true;
                    products.IsDeleted = true;
                    category.IsDeleted = true;
                    _location.Update(foundLocation);
                    _product.Update(products);
                    _category.Update(category);
                    await _product.SaveAsync();
                    await _category.SaveAsync();
                    await _location.SaveAsync();
                }
            }

            return new BaseResponse<ProductDto>
            {
                Status = true,
                Message = $"Successful!! Purchase {products.Name} From LawsonCompany",
            };
        }
        public async Task<BaseResponse<ProductDto>> Register(ProductRequestMode model)
        {
            var product = _product.Check(x => x.ProductCode == model.ProductCode);
            if (product == true)
            {
                return new BaseResponse<ProductDto>
                {
                    Status = false,
                    Message = "ProductCode Already exist",
                };
            }
            var category = new Category
            {

                Name = model.CategoryName,
                Price = model.PriceRange,
                Description = model.Description,
                DateCreated = DateTime.Now,
            };
            var products = new Product
            {
                Name = model.Name,
                Condition = model.Condition,
                ProductCode = model.ProductCode,
                Type = model.Type,
                Price = model.Price,
                SquareFeet = model.SquareFeet,
                SquareMeter = model.SquareFeet,
                CategoryId = category.Id,
                ProductImage = model.ProductImage,
                DateCreated = DateTime.Now,

            };
            var location = new Location()
            {
                Number = model.Number,
                Street = model.Street,
                City = model.City,
                State = model.State,
                Country = model.Country,
                CategoryId = category.Id,
                ProductId = products.Id,
                DateCreated = DateTime.Now,

            };
            await _category.CreateAsync(category);
            await _product.CreateAsync(products);
            await _location.CreateAsync(location);
            await _category.SaveAsync();
            await _product.SaveAsync();
            await _location.SaveAsync();
            return new BaseResponse<ProductDto>
            {
                Status = true,
                Message = "Data Add Successful",
                Data = new ProductDto
                {
                    Id = products.Id,
                    CategoryId = category.Id,
                    Condition = products.Condition,
                    Name = products.Name,
                    Price = products.Price,
                    ProductCode = products.ProductCode,
                    Type = products.Type,
                    SquareFeet = products.SquareFeet,
                    ProductImage = products.ProductImage,
                    SquareMeter = products.SquareMeter,
                    Locations = products.Locations.Select(x => new LocationDto
                    {
                        City = x.City,
                        Country = x.Country,
                        Number = x.Number,
                        State = x.State,
                        Street = x.Street,
                        Id = x.Id,
                    }).ToList(),
                }
            };
        }

        public async Task<BaseResponse<ProductDto>> Update(ProductUpdateModel model)
        {
            var update = await _product.Get(x => x.ProductCode == model.ProductCode);
            if (update == null)
            {
                return new BaseResponse<ProductDto>
                {
                    Status = false,
                    Message = "Data Not Found",
                };
            }
            var category = new Category
            {
                Price = model.Price,

            };
            var product = new Product
            {
                Price = model.Price,
                ProductCode = model.ProductCode,
                Type = model.Type,
            };
            _product.Update(product);
            await _product.SaveAsync();
            return new BaseResponse<ProductDto>
            {
                Status = true,
                Message = "Updated successful",
                Data = new ProductDto
                {
                    Id = product.Id,
                    CategoryId = category.Id,
                    Condition = product.Condition,
                    Name = product.Name,
                    Price = product.Price,
                    ProductCode = product.ProductCode,
                    Type = product.Type,
                    SquareFeet = product.SquareFeet,
                    SquareMeter = product.SquareMeter,
                    ProductImage = product.ProductImage,
                    Locations = product.Locations.Select(x => new LocationDto
                    {
                        City = x.City,
                        Country = x.Country,
                        Number = x.Number,
                        State = x.State,
                        Street = x.Street,
                    }).ToList(),
                }
            };
        }
    }
}