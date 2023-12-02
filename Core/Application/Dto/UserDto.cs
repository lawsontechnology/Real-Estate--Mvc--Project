using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Real_Estate.Core.Domain.Entities;

namespace Real_Estate.Core.Application.Dto
{
    public class UserDto
    {
        public string Id {get; set;} = default!;
        public string Email { get; set; } =default!;
        public string Password { get; set; } =default!;
        public string UserName { get; set; } =default!;
        public string ProfileId { get; set; } =default!;
        public Wallet Wallet { get; set; } =default!;
        public Manager Manager { get; set; } =default!;
        public Customer Customer { get; set; } =default!;
        public string RoleId { get; set; } =default!;
        public Role Roles { get; set; } =default!;
        
    }

    public class LoginRequestModel
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}