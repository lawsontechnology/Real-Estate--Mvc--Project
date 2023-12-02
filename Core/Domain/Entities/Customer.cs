using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Real_Estate.Core.Domain.Entities
{
    public class Customer : Auditable
    {
        public string UserId { get; set; } =default!;
        public string Email { get; set; } =default!;
    }
}