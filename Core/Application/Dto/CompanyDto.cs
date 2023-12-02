using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Real_Estate.Core.Application.Dto
{
    public class CompanyDto
    {
        public string Id {get; set;} = default!;
        public string Name { get; set; } =default!;
        public string CACRegNumber { get; set; } =default!;
        public string? Logo { get; set; }
        public string Address { get; set; } =default!;
        public string ManagerId { get; set; } =default!;
    }

    public class CompanyRequestMode 
    {
        public string Name { get; set; } =default!;
        public string CACRegNumber { get; set; } =default!;
        public string Address {get; set;} = default!;
        public string? Logo { get; set; } 
    }
}