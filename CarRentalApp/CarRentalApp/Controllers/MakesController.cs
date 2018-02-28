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
    [Route("/api/makes")]
    public class MakesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IVehicleRepository _vehicleRepository;

        public MakesController(IMapper mapper, IVehicleRepository vehicleRepository)
        {
            _mapper = mapper;
            _vehicleRepository = vehicleRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<MakeResource>> GetMakesAsync()
        {
            var makes = await _vehicleRepository.GetMakesWithModels();

            return _mapper.Map<List<Make>, List<MakeResource>>(makes);
        }
    }
}