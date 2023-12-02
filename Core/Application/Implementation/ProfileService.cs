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
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profile;
        private readonly IPhoneRepository _phone;
        private readonly IUserRepository _user;
        private readonly IAddressRepository _address;
        private readonly IRoleRepository _role;
        private readonly IWalletRepository _wallet;
        private readonly ICustomerRepository _customer;
        public ProfileService(IProfileRepository profile, IAddressRepository address, IPhoneRepository phone, IUserRepository user, IRoleRepository role, IWalletRepository wallet,ICustomerRepository customer)
        {
            _profile = profile;
            _address = address;
            _phone = phone;
            _user = user;
            _role = role;
            _customer = customer;
            _wallet = wallet;
        }

        public async Task<BaseResponse<ICollection<ProfileDto>>> GetAll()
        {
            List<ProfileDto> listOfProfile = new List<ProfileDto>();
            var profiles = await _profile.GetAll();
            foreach (var profi in profiles)
            {
                var address = await _address.Get(profi.AddressId);
                var phone = await _phone.Get(profi.PhoneId);
                var profile = new ProfileDto
                {
                    Id = profi.Id,
                    FirstName = profi.FirstName,
                    LastName = profi.LastName,
                    Dob = profi.Dob,
                    Image = profi.Image,
                    Email = profi.Email,
                    User = profi.User,
                    Address = new AddressDto
                    {
                         City = address.City,
                          Id = address.Id,
                           Number = address.Number,
                            PostalCode = address.PostalCode,
                             State = address.State,
                            Street = address.Street,
                              
                    },
                    Phone = new PhoneDto
                    {
                       Id = phone.Id,
                        CountryCode = phone.CountryCode,
                         PhoneNumber = phone.PhoneNumber,
    
                    }, 
                    
                    PhoneId = $"{phone.PhoneNumber} {phone.CountryCode}",
                    AddressId = $"{address.Number} {address.Street} {address.City} {address.State} {address.PostalCode}",
                };

                listOfProfile.Add(profile);
            }
            return new BaseResponse<ICollection<ProfileDto>>
            {
                Status = true,
                Message = "List of Profile",
                Data = listOfProfile,
            };
        }

        public async Task<BaseResponse<ProfileDto>> GetByEmail(string email)
        {
            var profile = await _profile.Get(email);
            var phone = await _phone.Get(profile.PhoneId);
            var address = await _address.Get(profile.AddressId);
            if (profile == null)
            {
                return new BaseResponse<ProfileDto>
                {
                    Status = false,
                    Message = "Data Not Found",

                };
            }
            return new BaseResponse<ProfileDto>
            {
                Status = true,
                Message = "Data SuccessFul Found",
                Data = new ProfileDto
                {

                    Id = profile.Id,
                    AddressId = address.Id,
                    Email = profile.Email,
                    FirstName = profile.FirstName,
                    LastName = profile.LastName,
                    Dob = profile.Dob,
                    Image = profile.Image,
                    PhoneId = phone.Id,
                    User = profile.User,
                    Address = new AddressDto
                    {
                         City = address.City,
                          Id = address.Id,
                           Number = address.Number,
                            PostalCode = address.PostalCode,
                             State = address.State,
                            Street = address.Street,
                              
                    },
                    Phone = new PhoneDto
                    {
                       Id = phone.Id,
                        CountryCode = phone.CountryCode,
                         PhoneNumber = phone.PhoneNumber,
    
                    }, 
                }
            };
        }

        public async Task<BaseResponse<ProfileDto>> GetById(string id)
        {
            var profile = await _profile.Get(id);
            var phone = await _phone.Get(profile.PhoneId);
            var address = await _address.Get(profile.AddressId);
            if (profile == null)
            {
                return new BaseResponse<ProfileDto>
                {
                    Status = false,
                    Message = "Data Not Found",
                };
            }
            return new BaseResponse<ProfileDto>
            {
                Status = true,
                Message = "Data SuccessFul Found",
                Data = new ProfileDto
                {
                   
                    Id = profile.Id,
                    AddressId = address.Id,
                    Email = profile.Email,
                    FirstName = profile.FirstName,
                    LastName = profile.LastName,
                    Dob = profile.Dob,
                    Image = profile.Image,
                    PhoneId = phone.Id,
                    User = profile.User,
                    Address = new AddressDto
                    {
                         City = address.City,
                          Id = address.Id,
                           Number = address.Number,
                            PostalCode = address.PostalCode,
                             State = address.State,
                            Street = address.Street,
                              
                    },
                    Phone = new PhoneDto
                    {
                       Id = phone.Id,
                        CountryCode = phone.CountryCode,
                         PhoneNumber = phone.PhoneNumber,
    
                    }, 
                }
            };
        }

        public async Task<BaseResponse<ProfileDto>> Register(ProfileRequestMode model)
        {
            var profile = await _profile.Get(x => x.Email == model.Email);
            if (profile != null)
            {
                return new BaseResponse<ProfileDto>
                {
                    Status = false,
                    Message = "Email Already Exists"
                };
            }
            var phone = new Phone
            {
                CountryCode = model.CountryCode,
                PhoneNumber = model.PhoneNumber,
                DateCreated = DateTime.Now,
            };
            var address = new Address
            {
                Number = model.Number,
                Street = model.Street,
                City = model.City,
                State = model.State,
                PostalCode = model.PostalCode,
                DateCreated = DateTime.Now,
            };
            var profiles = new Profile
            {
                AddressId = address.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneId = phone.Id,
                Dob = model.Dob,
                Image = model.Image,
                DateCreated = DateTime.Now,

            };
            var role = new Role
            {
               Name = "customer",
               Description = "Users",
               DateCreated = DateTime.Now,
            };
            var user = new User
            {
                Password = model.Password,
                Email = model.Email,
                UserName = model.UserName,
                ProfileId = profiles.Id,
                DateCreated = DateTime.Now,
                 RoleId = role.Id,
            };
            Wallet wallet = new Wallet
            {
               Balance = 0,
               UserId = user.Id,
               DateCreated = DateTime.Now,
            };
            var customer = new Customer
            {
              Email = model.Email,
              UserId = user.Id,
               DateCreated = DateTime.Now,
            };
            await _address.CreateAsync(address);
            await _phone.CreateAsync(phone);
            await _profile.CreateAsync(profiles);
            await _role.CreateAsync(role);
            await _user.CreateAsync(user);
            await _wallet.CreateAsync(wallet);
            await _customer.CreateAsync(customer);
            await _customer.SaveAsync();
            await _wallet.SaveAsync();
            await _role.SaveAsync();
            await _user.SaveAsync();
            await _address.SaveAsync();
            await _phone.SaveAsync();
            await _profile.SaveAsync();
            return new BaseResponse<ProfileDto>
            {
                Status = true,
                Message = "Successful",
                Data = new ProfileDto
                {
                    Id = profiles.Id,
                    AddressId = address.Id,
                    Email = profiles.Email,
                    FirstName = profiles.FirstName,
                    LastName = profiles.LastName,
                    Dob = profiles.Dob,
                    Image = profiles.Image,
                    PhoneId = phone.Id,
                    User = profiles.User,
                    Address = new AddressDto
                    {
                         City = address.City,
                          Id = address.Id,
                           Number = address.Number,
                            PostalCode = address.PostalCode,
                             State = address.State,
                            Street = address.Street,
                              
                    },
                    Phone = new PhoneDto
                    {
                       Id = phone.Id,
                        CountryCode = phone.CountryCode,
                         PhoneNumber = phone.PhoneNumber,
    
                    }, 
                }
            };
        }
    }
}