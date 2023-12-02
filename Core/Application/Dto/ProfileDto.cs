using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Real_Estate.Core.Domain.Entities;

namespace Real_Estate.Core.Application.Dto
{
    public class ProfileDto
    {
    public string Id { get; set; } = default!;
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string? Image { get; set; }
    public string PhoneId { get; set; } = default!;
    public PhoneDto Phone { get; set; } = new PhoneDto(); 
    public string Dob { get; set; } = default!;
    public string AddressId { get; set; } = default!;
    public AddressDto Address { get; set; } = new AddressDto();
    public User User { get; set; } = default!;
    }

    public class ProfileRequestMode
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string? Image { get; set; } 
        public string Email { get; set; } =default!;
        public string Password { get; set; } =default!;
        public string UserName { get; set; } =default!;
        public string PhoneNumber { get; set; } = default!;
        public string CountryCode {get; set;} = default!;
        public string Number { get; set; } = default!;
        public string Street { get; set; } = default!;
        public string City { get; set; } = default!;
        public string State { get; set; } = default!;
        public string PostalCode { get; set; } = default!;
        public string Dob { get; set; } = default!;
        
    }
}