using AutoMapper;
using ParcelManagementSystem.DTOs;
using ParcelManagementSystem.Models;

namespace ParcelManagementSystem.Profiles
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<Parcel ,ParcelReadDTO>();
            CreateMap<ParcelCreateDTO, Parcel>();
            CreateMap<ParcelUpdateDTO, Parcel>();
        }

    }
}
