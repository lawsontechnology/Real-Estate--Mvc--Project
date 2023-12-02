using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Real_Estate.Core.Domain.Entities
{
    public class Location : Auditable
    {
        public string Number { get; set; } = default!;
        public string Street { get; set; } = default!;
        public string City { get; set; } = default!;
        public string State { get; set; } = default!;
        public string Country {get; set;} = default!;
        public string CategoryId {get; set;} 
        public string ProductId {get; set;}
        
    }
}