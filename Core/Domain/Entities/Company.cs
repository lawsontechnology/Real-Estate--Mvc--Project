using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Real_Estate.Core.Domain.Entities
{
    public class Company : Auditable
    {
        public string Name { get; set; } =default!;
        public string CACRegNumber { get; set; } =default!;
        public string Logo { get; set; }
        public string Address { get; set; } =default!;
        public string ManagerId { get; set; } =default!;
       
    }
}