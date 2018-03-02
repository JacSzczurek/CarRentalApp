using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarRentalApp.Controllers.Resources;
using CarRentalApp.Core.Model;
using CarRentalApp.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalApp.Controllers
{
    [Route("api/features")]
    public class FeaturesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IVehicleRepository _vehicleRepository;

        public FeaturesController(IMapper mapper, IVehicleRepository vehicleRepository)
        {
            _mapper = mapper;
            _vehicleRepository = vehicleRepository;
        }
        [HttpGet]
        public async Task<List<KeyValueResource>> GetFeatures()
        {
            var features = await _vehicleRepository.GetAllFeatures();

            return _mapper.Map<List<Feature>, List<KeyValueResource>>(features);
        }
    }
}