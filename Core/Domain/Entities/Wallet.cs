using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Real_Estate.Core.Domain.Entities
{
    public class Wallet : Auditable
    {
        public double Balance { get; set; }
        public string UserId { get; set; } =default!;
    }
}