using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Real_Estate.Core.Domain.Entities
{
    public class Manager : Auditable
    {
        public string UserId { get; set; } =default!;
        public string Email {get; set;} = default!;
        public string StaffNumber { get; set; } =default!;
        public string FullName {get; set;} = default!;
        public string PhoneNumber {get; set;} = default!;
    }
}