using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Real_Estate.Core.Application.Dto
{
    public class CustomerDto
    {
        public string Id { get; set; } = default!;
        public string UserId { get; set; } = default!;
        public string Email { get; set; } = default!;
    }
}