﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentalApp.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApp.Persistence
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly CarRentalDbContext _context;

        public VehicleRepository(CarRentalDbContext carRentalDbContext)
        {
            _context = carRentalDbContext;
        }

        public async Task<List<Make>> GetMakesWithModels()
        {
            return await _context.Makes
                .Include(m => m.Models).ToListAsync();
        }

        public async Task<List<Vehicle>> GetAllVehicles()
        {
            return await _context.Vehicles
                .Include(s => s.VehicleFeatures)
                    .ThenInclude(vf => vf.Feature)
                .Include(p => p.Photos)
                .Include(m => m.Model)
                    .ThenInclude(m => m.Make).ToListAsync();
        }
    }
}
