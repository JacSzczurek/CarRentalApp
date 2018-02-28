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
    [Route("/api/vehicles/")]
    public class VehiclesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IVehicleRepository _vehicleRepository;

        public VehiclesController(IMapper mapper, IVehicleRepository vehicleRepository)
        {
            _mapper = mapper;
            _vehicleRepository = vehicleRepository;
        }

        [HttpGet]
        public async Task<List<VehicleResource>> GetVehicles()
        {
            var vehicles = await _vehicleRepository.GetAllVehicles();

            return _mapper.Map<List<Vehicle>, List<VehicleResource>>(vehicles);
        }
    }
}