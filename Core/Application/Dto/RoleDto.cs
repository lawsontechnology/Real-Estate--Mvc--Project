using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Real_Estate.Core.Domain.Entities;

namespace Real_Estate.Core.Application.Dto
{
    public class RoleDto
    {
        public string Id {get; set;} = default!;
        public string Name { get; set; }  =default!;
        public string Description { get; set; } =default!;
        
    }

    public class RoleRequestMode
    {
        public string Name {get; set;} = default!;
        public string Description {get; set;} = default!;
    }
}