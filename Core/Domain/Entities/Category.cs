using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Real_Estate.Core.Domain.Entities
{
    public class Category : Auditable
    {
        public string Name { get; set; } = default!;
        public double Price {get; set;} 
        public string Description { get; set; } =default!;
        public List<Product> Products { get; set; } = new List<Product>();
        public List<Location> Locations {get; set;} = new List<Location>();
    }
}