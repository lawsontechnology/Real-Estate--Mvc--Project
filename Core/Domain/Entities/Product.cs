using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Real_Estate.Core.Domain.Entities
{
    public class Product : Auditable
    {
        public string Name { get; set; } =default!;
        public string SquareFeet { get; set; } =default!;
        public string SquareMeter {get; set;} = default!;
        public string Type {get; set;} = default!;
        public string Condition {get; set; } = default!;
        public double Price { get; set; } =default!;
        public string ProductCode {get; set;} = default!;
        public string ProductImage {get; set;} 
        public string CategoryId { get; set; } =default!;
        public List<Location> Locations {get; set;} =default!;
    }
}