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
            CreateMap<Vehicle, VehicleResource>()
                .ForMember(dest => dest.Make, opt => opt.MapFrom(source => source.Model.Make))
                .ForMember(dest => dest.Features, opt => opt.MapFrom(source => source.VehicleFeatures.Select(vf => new KeyValueResource { Id = vf.Feature.Id, Name = vf.Feature.Name})));
            CreateMap(typeof(QueryResult<>), typeof(QueryResultResource<>));

            CreateMap<Make, KeyValueResource>();
            CreateMap<Model, KeyValueResource>();
            CreateMap<Photo, KeyValueResource>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(source => source.Filename));
            CreateMap<Feature, KeyValueResource>();

            #endregion DOMAIN_TO_API

            #region API_TO_DOMAIN

            CreateMap<SaveVehicleResource, Vehicle>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.VehicleFeatures, opt => opt.Ignore())
                .AfterMap((source, dest) =>
                {
                    //UPDATE FEATURES
                    var toRemoveFeatures = dest.VehicleFeatures.Where(f => !source.Features.Contains(f.FeatureId)).ToList();

                    foreach (var vehicleFeature in toRemoveFeatures)
                    {
                        dest.VehicleFeatures.Remove(vehicleFeature);
                    }

                    //ADD FEATURES
                    var addedFeatures = source.Features
                        .Where(id => !dest.VehicleFeatures.Any(f => f.FeatureId == id))
                        .Select(id => new VehicleFeature { FeatureId = id }).ToList();
                    foreach (var vehicleFeature in addedFeatures)
                    {
                        dest.VehicleFeatures.Add(vehicleFeature);
                    }
                });

            #endregion API_TO_DOMAIN

        }
    }
}
