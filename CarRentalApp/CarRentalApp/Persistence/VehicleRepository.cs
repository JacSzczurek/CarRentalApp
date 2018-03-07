using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CarRentalApp.Controllers.Resources;
using CarRentalApp.Core.Model;
using CarRentalApp.Extensions;
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

        public async Task<QueryResult<Vehicle>> GetVehicles(VehicleQuery filtersQuery)
        {
            var result = new QueryResult<Vehicle>();
            var query = GetAllVehicles();

            query = query.ApplyFiltering(filtersQuery);

            var columnsMap = new Dictionary<string, Expression<Func<Vehicle, object>>>
            {
                ["make"] = v => v.Model.Make.Name,
                ["model"] = v => v.Model.Name,
                ["id"] = v => v.Id,
            };
            query = query.ApplyOrdering(filtersQuery, columnsMap);

            result.ItemsCount = await query.CountAsync();

            query = query.ApplyPagination(filtersQuery);

            result.Items = await query.ToListAsync();

            return result;
        }

        public async Task<Vehicle> GetVehicle(int id)
        {
            return await _context.Vehicles
                .Include(v => v.VehicleFeatures)
                    .ThenInclude(vf => vf.Feature)
                .Include(v => v.Model)
                    .ThenInclude(m => m.Make)
                .SingleOrDefaultAsync(v => v.Id == id);
        }

        public async Task<List<Feature>> GetAllFeatures()
        {
            return await _context.Features.ToListAsync();
        }

        public async Task AddVehicle(Vehicle vehicle)
        {
            await _context.AddAsync(vehicle);
        }

        #region Private

        private IQueryable<Vehicle> GetAllVehicles()
        {
            return _context.Vehicles
                .Include(s => s.VehicleFeatures)
                .ThenInclude(vf => vf.Feature)
                .Include(p => p.Photos)
                .Include(m => m.Model)
                .ThenInclude(m => m.Make).AsQueryable();
        }

        #endregion

    }
}
