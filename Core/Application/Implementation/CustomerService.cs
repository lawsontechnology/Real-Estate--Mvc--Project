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
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customer;
        private readonly IUserRepository _user;
        public CustomerService(ICustomerRepository customer, IUserRepository user)
        {
            _customer = customer;
            _user = user;
        }

        public async Task<BaseResponse<CustomerDto>> Delete(string CustomerId)
        {
            var customer = await _customer.Get(CustomerId);
            var user = await _user.Get(customer.UserId);
            if (customer == null)
            {
                return new BaseResponse<CustomerDto>
                {
                    Status = false,
                    Message = "Customer Not Found",
                };
            }
            await _customer.Delete(CustomerId);
            _customer.Update(customer);

            return new BaseResponse<CustomerDto>
            {
                Status = true,
                Message = "Successful Deleted",
                Data = new CustomerDto
                {
                    Id = customer.Id,
                    Email = customer.Email,
                    UserId = user.Id,
                }
            };
        }

        public async Task<BaseResponse<ICollection<CustomerDto>>> GetAll()
        {
            List<CustomerDto> listOfCustomer = new List<CustomerDto>();
            var customers = await _customer.GetAll();
            foreach (var customer in customers)
            {
                var user = await _user.Get(customer.UserId);
                var Customers = new CustomerDto
                {
                    Id = customer.Id,
                    Email = customer.Email,
                    UserId = user.Id,
                };
                listOfCustomer.Add(Customers);
            }
            return new BaseResponse<ICollection<CustomerDto>>
            {
                Status = true,
                Message = "List Of Customer",
                Data = listOfCustomer,
            };
        }

        public async Task<BaseResponse<CustomerDto>> GetById(string id)
        {
            var check = await _customer.Get(x => x.Id == id);
            var user = await _user.Get(check.UserId);
            if (check == null)
            {
                return new BaseResponse<CustomerDto>
                {
                    Status = false,
                    Message = "Not Found",
                };

            }
            return new BaseResponse<CustomerDto>
            {
                Status = true,
                Message = "Customer Found",
                Data = new CustomerDto
                {
                    Id = check.Id,
                    Email = check.Email,
                    UserId = user.Id,
                }
            };
        }
    }
}