using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Real_Estate.Core.Application.Dto;

namespace Real_Estate.Core.Application.Interface.Service
{
    public interface IWalletservice
    {
        Task<BaseResponse<WalletDto>> AddWallet(AddToWalletRequestModel model, string id);
        Task<BaseResponse<WalletDto>> Get( string id);
        Task<BaseResponse<WalletDto>> Debit (DebitFromWalletRequestModel model, string id);
    }
}