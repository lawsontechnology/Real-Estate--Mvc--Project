using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Real_Estate.Core.Application.Dto
{
    public class WalletDto
    {
        public string Id {get; set;} = default!;
        public double Balance { get; set; }
        public string UserId { get; set; } =default!;
    }

    public class AddToWalletRequestModel
    {
        public double Amount {get; set;}
    }
    public class DebitFromWalletRequestModel
    {
        public double Amount {get; set;}
    }
}