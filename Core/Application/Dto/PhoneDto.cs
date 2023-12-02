using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Real_Estate.Core.Application.Dto
{
    public class PhoneDto
    {
        public string Id { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string CountryCode { get; set; } = default!;
    }
}