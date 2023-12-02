using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Real_Estate.Core.Domain.Entities
{
    public class Phone : Auditable
    {
        public string PhoneNumber {get; set;} = default!;
        public string CountryCode {get; set;} = default!;
    }
}