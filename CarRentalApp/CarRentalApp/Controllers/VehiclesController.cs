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
    [Route("/api/vehicles")]
    public class VehiclesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public VehiclesController(IMapper mapper, IVehicleRepository vehicleRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _vehicleRepository = vehicleRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            var vehicle = await _vehicleRepository.GetVehicle(id);
            if (vehicle == null)
                return NotFound();

            return Ok(_mapper.Map<Vehicle, VehicleResource>(vehicle));
        }
        [HttpGet]
        public async Task<QueryResultResource<VehicleResource>> GetVehicles(VehicleQueryResource filtersQuery)
        {
            var query = _mapper.Map<VehicleQueryResource, VehicleQuery>(filtersQuery);
            var vehicles = await _vehicleRepository.GetVehicles(query);
            return _mapper.Map<QueryResult<Vehicle>, QueryResultResource<VehicleResource>>(vehicles);
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] SaveVehicleResource vehicleResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vehicle = _mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource);
            vehicle.Creationdate = DateTime.Now;
            await _vehicleRepository.AddVehicle(vehicle);
            await _unitOfWork.CompleteAsync();

            vehicle = await _vehicleRepository.GetVehicle(vehicle.Id);

            return Ok(_mapper.Map<Vehicle, VehicleResource>(vehicle));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody] SaveVehicleResource saveVehicleResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vehicle = await _vehicleRepository.GetVehicle(id);

            if (vehicle == null)
                return NotFound();

            _mapper.Map<SaveVehicleResource, Vehicle>(saveVehicleResource, vehicle);

            await _unitOfWork.CompleteAsync();
            vehicle = await _vehicleRepository.GetVehicle(vehicle.Id);

            return Ok(_mapper.Map<Vehicle, VehicleResource>(vehicle));
        }
    }
}