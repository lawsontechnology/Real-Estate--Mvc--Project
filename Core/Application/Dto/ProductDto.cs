using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Real_Estate.Core.Domain.Entities;


namespace Real_Estate.Core.Application.Dto
{
    public class ProductDto
    {
        public string Id {get; set;} = default!;
        public string Name { get; set; } =default!;
        public string SquareFeet { get; set; } =default!;
        public string SquareMeter {get; set;} = default!;
        public string Type {get; set;} = default!;
        public string Condition {get; set; } = default!;
        public string ProductCode {get; set;} = default!;
        public double Price { get; set; } =default!;
        public string CategoryId { get; set; } =default!;
        public string? ProductImage {get; set;} 
         public bool IsDeleted{get; set;}
        public CategoryDto Category {get; set;} = new CategoryDto();
        public ICollection<LocationDto> Locations {get; set;} = new HashSet<LocationDto>();
    }

    public class ProductRequestMode
    {
        public string Name { get; set; } =default!;
        public string SquareFeet { get; set; } =default!;
        public string SquareMeter {get; set;} = default!;
        public string ProductCode {get; set;} = default!;
        public string Condition {get; set; } = default!;
        public string Type {get; set;} = default!;
        public string? ProductImage {get; set;} 
        public double Price { get; set; } =default!;
        public string Number { get; set; } = default!;
        public string Street { get; set; } = default!;
        public string? CategoryName {get; set;}
        public double PriceRange {get; set; }
        public string? Description {get; set;}
        public string City { get; set; } = default!;
        public string State { get; set; } = default!;
        public string Country { get; set; } = default!;
    }

    public class ProductUpdateModel
    {
        public string? Type {get; set;}
        public double Price { get; set; } 
        public string? ProductCode {get; set;}
    }
}