using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Real_Estate.Core.Application.Dto
{
    public class ManagerDto
    {
        public string Id { get; set; } = default!;
        public string UserId { get; set; } = default!;
        public string StaffNumber { get; set; } = default!;
        public string Email {get; set;} = default!;
        public string FullName {get; set;} = default!;
        public string PhoneNumber {get; set;} = default!;
    }

    public class ManagerRequestMode
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string StaffNumber {get; set;} = default!;
        public string Email { get; set; } =default!;
        public string Password { get; set; } =default!;
        public string PhoneNumber { get; set; } = default!;
        public string CountryCode {get; set;} = default!;
        public string Number { get; set; } = default!;
        public string Street { get; set; } = default!;
        public string City { get; set; } = default!;
        public string State { get; set; } = default!;
        public string PostalCode { get; set; } = default!;
        public string RoleName {get; set;} = default!;
        public string Description {get; set;} = default!;
    }
}