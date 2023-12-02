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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _category;
        public CategoryService(ICategoryRepository category)
        {
            _category = category;
        }


        public async Task<BaseResponse<ICollection<CategoryDto>>> GetAll()
        {
            List<CategoryDto> ListOfCategories = new List<CategoryDto>();
            var categories = await _category.GetAll();
            foreach (var Category in categories)
            {
                var categorys = new CategoryDto
                {
                    Id = Category.Id,
                    CategoryName = Category.Name,
                    PriceRange = Category.Price,
                    Description = Category.Description,
                    Locations = Category.Locations.Select(x => new Location
                    {
                        Id = x.Id,
                        City = x.City,
                        Country = x.Country,
                        Number = x.Number,
                        State = x.State,
                        Street = x.Street,
                    }).ToList(),
                    Products = Category.Products.Select(x => new Product
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Price = x.Price,
                        ProductCode = x.ProductCode,
                        Type = x.Type,
                        SquareFeet = x.SquareFeet,
                        SquareMeter = x.SquareMeter,
                        Locations = x.Locations,
                        Condition = x.Condition,
                        CategoryId = x.CategoryId,

                    }).ToList(),
                };
                ListOfCategories.Add(categorys);
            }
            return new BaseResponse<ICollection<CategoryDto>>
            {
                Status = true,
                Message = "List of Category",
                Data = ListOfCategories,
            };
        }

        public async Task<BaseResponse<CategoryDto>> GetByName(string Name)
        {
            var Category = await _category.Get(x => x.Name == Name);
            if (Category == null)
            {
                return new BaseResponse<CategoryDto>
                {
                    Status = false,
                    Message = "Not Found",
                };
            }
            return new BaseResponse<CategoryDto>
            {
                Status = true,
                Message = "Found",
                Data = new CategoryDto
                {
                    Id = Category.Id,
                    CategoryName = Category.Name,
                    PriceRange = Category.Price,
                    Description = Category.Description,
                    Locations = Category.Locations.Select(x => new Location
                    {
                        Id = x.Id,
                        City = x.City,
                        Country = x.Country,
                        Number = x.Number,
                        State = x.State,
                        Street = x.Street,
                    }).ToList(),
                    Products = Category.Products.Select(x => new Product
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Price = x.Price,
                        ProductCode = x.ProductCode,
                        Type = x.Type,
                        SquareFeet = x.SquareFeet,
                        SquareMeter = x.SquareMeter,
                        Locations = x.Locations,
                        Condition = x.Condition,
                        CategoryId = x.CategoryId,

                    }).ToList(),
                }
            };
        }

        public async Task<BaseResponse<CategoryDto>> GetByPrice(double Price)
        {
            var Category = await _category.Get(x => x.Price == Price);
            if (Category == null)
            {
                return new BaseResponse<CategoryDto>
                {
                    Status = false,
                    Message = "Not Found",
                };
            }
            return new BaseResponse<CategoryDto>
            {
                Status = true,
                Message = "Found",
                Data = new CategoryDto
                {
                    Id = Category.Id,
                    CategoryName = Category.Name,
                    PriceRange = Category.Price,
                    Description = Category.Description,
                    Locations = Category.Locations.Select(x => new Location
                    {
                        Id = x.Id,
                        City = x.City,
                        Country = x.Country,
                        Number = x.Number,
                        State = x.State,
                        Street = x.Street,
                    }).ToList(),
                    Products = Category.Products.Select(x => new Product
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Price = x.Price,
                        ProductCode = x.ProductCode,
                        Type = x.Type,
                        SquareFeet = x.SquareFeet,
                        SquareMeter = x.SquareMeter,
                        Locations = x.Locations,
                        Condition = x.Condition,
                        CategoryId = x.CategoryId,

                    }).ToList(),
                }
            };
        }

        public async Task<BaseResponse<CategoryDto>> Delete(string id)
        {
            var Category = await _category.Get(id);
            if (Category == null)
            {
                return new BaseResponse<CategoryDto>
                {
                    Status = false,
                    Message = "Category Not Found"
                };
            }
            await _category.Delete(id);
            _category.Update(Category);
            return new BaseResponse<CategoryDto>
            {
                Status = true,
                Message = "SuccessFul Deleted",
                Data = new CategoryDto
                {
                    Id = Category.Id,
                    CategoryName = Category.Name,
                    PriceRange = Category.Price,
                    Description = Category.Description,
                    Locations = Category.Locations.Select(x => new Location
                    {
                        Id = x.Id,
                        City = x.City,
                        Country = x.Country,
                        Number = x.Number,
                        State = x.State,
                        Street = x.Street,
                    }).ToList(),
                    Products = Category.Products.Select(x => new Product
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Price = x.Price,
                        ProductCode = x.ProductCode,
                        Type = x.Type,
                        SquareFeet = x.SquareFeet,
                        SquareMeter = x.SquareMeter,
                        Locations = x.Locations,
                        Condition = x.Condition,
                        CategoryId = x.CategoryId,

                    }).ToList(),

                }
            };
        }
    }
}