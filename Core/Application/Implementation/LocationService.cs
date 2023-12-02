using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Real_Estate.Core.Application.Dto;
using Real_Estate.Core.Application.Interface.Repository;
using Real_Estate.Core.Application.Interface.Service;
using Real_Estate.Core.Domain.Entities;

namespace Real_Estate.Core.Application.Implementation
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _location;
        // private readonly IMapper _mapper;
        public LocationService(ILocationRepository location)
        {
            _location = location;
            // _mapper = mapper;
        }

        public  async Task<BaseResponse<LocationDto>> Delete(string LocationId)
        {
           var location = await _location.Get(LocationId);
           if (location == null)
           {
             return new BaseResponse<LocationDto>
             {
                Status = false,
                Message = "Location Not Found",
             };
           }

           await _location.Delete(LocationId);
           _location.Update(location);
           return new BaseResponse<LocationDto>
           {
             Status = true,
             Message = "Successful Deleted",
              Data = new LocationDto
                {
                    Id = location.Id,
                    Number = location.Number,
                    Street = location.Street,
                    City = location.City,
                    State = location.State,
                    Country = location.Country,
                }
           };
        }

        public async Task<BaseResponse<LocationDto>> Get(string State)
        {
            var check = await _location.Get(x => x.State == State);
            if (check == null)
            {
                return new BaseResponse<LocationDto>
                {
                    Status = false,
                    Message = "Not Found",
                };

            }
            return new BaseResponse<LocationDto>
            {
                Status = true,
                Message = "Location Found",
                Data = new LocationDto
                {
                    Id = check.Id,
                    Number = check.Number,
                    Street = check.Street,
                    City = check.City,
                    State = check.State,
                    Country = check.Country,
                }
            };
        }

        public async Task<BaseResponse<ICollection<LocationDto>>> GetAll()
        {
          List<LocationDto> ListOflocation = new List<LocationDto>();
          var location = await _location.GetAll();
          foreach (var locations in location)
          {
                var locationList = new LocationDto
                {
                    Id = locations.Id,
                    Number = locations.Number,
                    Street = locations.Street,
                    City = locations.City,
                    State = locations.State,
                    Country = locations.Country,
                    
                };
                ListOflocation.Add(locationList);
          } 
          return new BaseResponse<ICollection<LocationDto>>
          {
            Status = true,
            Message = "Successful Found",
            Data = ListOflocation,
          };
        }

        public async Task<BaseResponse<LocationDto>> GetById(string id)
        {
            var check = await _location.Get(x => x.Id == id);
            if (check == null)
            {
                return new BaseResponse<LocationDto>
                {
                    Status = false,
                    Message = "Not Found",
                };

            }
            return new BaseResponse<LocationDto>
            {
                Status = true,
                Message = "Location Found",
                Data = new LocationDto
                {
                    Id = check.Id,
                    Number = check.Number,
                    Street = check.Street,
                    City = check.City,
                    State = check.State,
                    Country = check.Country,
                }
            };
        }

        public async Task<BaseResponse<LocationDto>> RemoveLocation(string id)
        {
            var location = await _location.Get(id);
            var locations = location.IsDeleted = true;
            _location.Update(location);
            await _location.SaveAsync();
             return new BaseResponse<LocationDto>
            {
                Status = true,
                Message = $"At No:{location.Number},Street:{location.Street},City:{location.City},State:{location.State}",
                Data = new LocationDto
                {
                   IsDeleted = locations,
                }
            };

        }
    }
}