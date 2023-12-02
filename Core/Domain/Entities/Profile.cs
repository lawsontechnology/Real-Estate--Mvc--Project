using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Real_Estate.Core.Domain.Entities
{
    public class Profile : Auditable
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email {get; set;} = default!;
        public string? Image { get; set; } = default!;
        public string PhoneId { get; set; } = default!;
        public Phone Phone { get; set; }
        public string Dob { get; set; } = default!;
        public string AddressId { get; set; } = default!;
        public Address Address { get; set; } 
        public User User { get; set; } = default!;
    }
}