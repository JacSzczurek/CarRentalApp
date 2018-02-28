using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarRentalApp.Controllers.Resources;
using CarRentalApp.Core.Model;

namespace CarRentalApp.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            #region DOMAIN_TO_API

            CreateMap<Make, MakeResource>();
            CreateMap<Vehicle, VehicleResource>();

            CreateMap<Make, KeyValueResource>();
            CreateMap<Model, KeyValueResource>();
            CreateMap<Photo, KeyValueResource>().ForMember(dest => dest.Name, opt => opt.MapFrom(source => source.Filename));

            #endregion DOMAIN_TO_API

            #region API_TO_DOMAIN


            #endregion API_TO_DOMAIN

        }
    }
}
