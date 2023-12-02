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
    public class ManagerService : IManagerService
    {
        private readonly IManagerRepository _manager;
        private readonly IUserRepository _user;
        private readonly IProfileRepository _profile;
        private readonly IAddressRepository _address;
        private readonly IPhoneRepository _phone;
        private readonly IRoleRepository _role;
        // private readonly IMapper _mapper;
        public ManagerService(IManagerRepository manager, IUserRepository user, IProfileRepository profile,IAddressRepository address,IPhoneRepository phone,IRoleRepository role)
        {
            _manager = manager;
            _profile = profile;
            _user = user;
            _address = address;
            _phone = phone;
            _role = role;
            // _mapper = mapper;
        }

        public async Task<BaseResponse<ManagerDto>> Delete(string ManagerId)
        {
            var manager = await _manager.Get(ManagerId);
            
            if (manager == null)
            {
                return new BaseResponse<ManagerDto>
                {
                    Status = false,
                    Message = "Manager not found.",
                };
            }

            await _manager.Delete(ManagerId);
            _manager.Update(manager);
            return new BaseResponse<ManagerDto>
            {
                Message = "successful Deleted",
                Status = true,
                Data = new ManagerDto
                {
                    Id = manager.Id,
                    StaffNumber = manager.StaffNumber,
                    FullName = manager.FullName,
                    PhoneNumber = manager.PhoneNumber,
                }
            };
        }

        public async Task<BaseResponse<ManagerDto>> Get(string staffNumber)
        {
            var manager = await _manager.Get(x => x.StaffNumber == staffNumber);
            if(manager == null)
            {
                return new BaseResponse<ManagerDto>
                {
                    Status = false,
                  Message = "Data Not Found",
                };
            }
            return new BaseResponse<ManagerDto>
            {
                Status = true,
                Message = "Data  Found",
                Data = new ManagerDto
                {
                    Id = manager.Id,
                    StaffNumber = manager.StaffNumber,
                    Email = manager.Email,
                    FullName = manager.FullName,
                    PhoneNumber = manager.PhoneNumber,
                }
            };
        }

        public async Task<BaseResponse<ICollection<ManagerDto>>> GetAll()
        {
            List<ManagerDto> listOfManagers = new List<ManagerDto>();
            var manage = await _manager.GetAll();
            foreach (var manager in manage)
            {
                var managers = new ManagerDto
                {
                    Id = manager.Id,
                    StaffNumber = manager.StaffNumber,
                    Email = manager.Email,
                    FullName = manager.FullName,
                    PhoneNumber = manager.PhoneNumber,
                };
                listOfManagers.Add(managers);
            }
            return new BaseResponse<ICollection<ManagerDto>>
            {
                Status = true,
                Message = "successful",
                Data = listOfManagers,
            };
        }

        public async Task<BaseResponse<ManagerDto>> Register(ManagerRequestMode model)
        {
            var manager = _manager.Check(x => x.StaffNumber == model.StaffNumber && x.Email == model.Email);
            if (manager == true)
            {
                return new BaseResponse<ManagerDto>
                {
                    Status = false,
                    Message = "Staff Already Exists"
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
            var profile = new Profile
            {
                AddressId = address.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneId = phone.Id,
                DateCreated = DateTime.Now,
            };
            var role = new Role
            {
               Name = "Manager",
               Description = "staff",
               DateCreated = DateTime.Now,
            };
            var user = new User
            {
                Password = model.Password,
                Email = model.Email,
                DateCreated = DateTime.Now,
                ProfileId = profile.Id,
                RoleId = role.Id,
            };
            var managers = new Manager
            {
                StaffNumber = model.StaffNumber,
                UserId = user.Id,
                Email = model.Email,
                FullName = model.FirstName +""+model.LastName,
                PhoneNumber = model.PhoneNumber,
                DateCreated = DateTime.Now,
                
            };
            
            await _phone.CreateAsync(phone);
            await _address.CreateAsync(address);
            await _profile.CreateAsync(profile);
            await _user.CreateAsync(user);
            await _manager.CreateAsync(managers);
            await _role.CreateAsync(role);
            await _role.SaveAsync();
            await _address.SaveAsync();
            await _phone.SaveAsync();
            await _profile.SaveAsync();
            await _user.SaveAsync();
            await _manager.SaveAsync();
            return new BaseResponse<ManagerDto>
            {
                Status = true,
                Message = "successful",
                Data = new ManagerDto
                {
                    Id = managers.Id,
                    StaffNumber = managers.StaffNumber,
                    UserId = user.Id,
                    Email = managers.Email,
                    FullName = managers.FullName,
                    PhoneNumber = managers.PhoneNumber,
                }
            };
        }
    }
}