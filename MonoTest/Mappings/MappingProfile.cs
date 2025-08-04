using AutoMapper;
using MonoTest.Models;
using MonoTest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonoTest.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<VehicleMake, VehicleMakeViewModel>()
                .ForMember(dest => dest.VehicleModels, opt => opt.MapFrom(src => src.VehicleModels))
                .ReverseMap();
            CreateMap<VehicleModel, VehicleModelViewModel>().ReverseMap();
        }
    }
}