using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Real_Estate.Core.Application.Dto;
using Real_Estate.Core.Application.Interface.Repository;
using Real_Estate.Core.Application.Interface.Service;
using Real_Estate.Core.Domain.Entities;

namespace Real_Estate.Core.Application.Implementation
{
    public class WalletService : IWalletservice
    {
        private readonly IWalletRepository _wallet;
        private readonly ICustomerRepository _customer;
        public WalletService(IWalletRepository wallet, ICustomerRepository customer)
        {
            _wallet = wallet;
            _customer = customer;
        }

        public async Task<BaseResponse<WalletDto>> AddWallet(AddToWalletRequestModel model, string id)
        {
            var customer = await _customer.Get(x => x.UserId == id);
            if (model.Amount <= 0)
            {
                return new BaseResponse<WalletDto>
                {
                    Message = "Amount must be greater than Zero",
                    Status = false,
                };
            }
            var wallet = await _wallet.Get(id);
            wallet.Balance += model.Amount;
            _wallet.Update(wallet);
            await _wallet.SaveAsync();
            return new BaseResponse<WalletDto>
            {
                Status = true,
                Message = "Successful",
                Data = new WalletDto
                {
                    Id = wallet.Id,
                    Balance = wallet.Balance,
                    UserId = id,
                }
            };
        }

        public async Task<BaseResponse<WalletDto>> Debit(DebitFromWalletRequestModel model, string id)
        {
            var wallet = await _wallet.Get(x => x.UserId == id);
            if (wallet.Balance < model.Amount)
            {
                return new BaseResponse<WalletDto>
                {
                    Message = "Wallet Balance is Low",
                    Status = false,
                };
            }
            wallet.Balance -= model.Amount;
            
            await _wallet.SaveAsync();
            return new BaseResponse<WalletDto>
            {
                Status = true,
                Message = "Successful",
                Data = new WalletDto
                {
                    Id = wallet.Id,
                    Balance = wallet.Balance,
                    UserId = id,
                }
            };
        }

        public async Task<BaseResponse<WalletDto>> Get(string id)
        {
            var wallet = await _wallet.Get(x => x.UserId == id);
            if (wallet == null)
            {
                return new BaseResponse<WalletDto>
                {
                    Message = "Not Found",
                    Status = false,
                };
            }
            return new BaseResponse<WalletDto>
            {
                Message = "Found",
                Status = true,
                Data = new WalletDto
                {
                    Balance = wallet.Balance,
                    UserId = wallet.UserId,
                    Id = wallet.Id,
                }
            };
        }
    }
}