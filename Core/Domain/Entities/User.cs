using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Real_Estate.Core.Domain.Entities
{
    public class User : Auditable
    {
        public string Email { get; set; } =default!;
        public string Password { get; set; } =default!;
        public string UserName { get; set; } =default!;
        public string ProfileId { get; set; } =default!;
        public Profile Profile { get; set; } =default!;
        public Wallet Wallet { get; set; } =default!;
        public Manager Manager { get; set; } =default!;
        public Customer Customer { get; set; } =default!;
        public string RoleId {get; set;} = default!;
        public Role Roles {get; set;} = default!;
        
    }
}