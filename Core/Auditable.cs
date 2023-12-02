using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Real_Estate.Core
{
    public abstract class Auditable
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public bool IsDeleted { get; set; } = default!;
        public string?  DeletedBy { get; set; }
        public DateTime? DateCreated { get; set; } 
    }
}