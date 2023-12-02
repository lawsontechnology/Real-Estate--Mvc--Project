using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Real_Estate.Core.Application.Dto;
using Real_Estate.Core.Application.Interface.Repository;
using Real_Estate.Core.Application.Interface.Service;

namespace Real_Estate.Core.Application.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _user;
        public UserService(IUserRepository user)
        {
            _user = user;
        }
        public async Task<BaseResponse<UserDto>> Login(LoginRequestModel model)
        {
            var user = await _user.Get(x => x.Email == model.Email && x.Password == model.Password);
            if (user == null)
            {
                return new BaseResponse<UserDto>
                {
                    Status = false,
                    Message = "invalid credentials",

                };
            }
            return new BaseResponse<UserDto>
            {
                Status = true,
                Message = "Successful Login",
                Data = new UserDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    Password = user.Password,
                    UserName = user.UserName,
                    RoleId = user.RoleId,
                    ProfileId = user.ProfileId,
                    Customer = user.Customer,
                    Manager = user.Manager,
                    Wallet = user.Wallet,
                    Roles = user.Roles,
                    
                }
            };
        }
    }
}