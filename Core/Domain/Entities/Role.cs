using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Real_Estate.Core.Domain.Entities
{
    public class Role : Auditable
    {
        public string Name { get; set; }  =default!;
        public string Description { get; set; } =default!;
        
    }
}