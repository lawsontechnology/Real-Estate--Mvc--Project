using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Real_Estate.Core.Domain.Entities;

namespace Real_Estate.Core.Application.Dto
{
    public class CategoryDto
    { 
        public string Id {get; set;} = default!;
        public string? CategoryName { get; set; }
        public double PriceRange {get; set;}
        public string Description { get; set; } =default!;
        public List<Product> Products { get; set; } = new List<Product>();
        public List<Location> Locations {get; set;} = new List<Location>();
    }

    
}