using System.Collections.Generic;
using System.Threading.Tasks;
using CarRentalApp.Controllers.Resources;
using CarRentalApp.Core.Model;

namespace CarRentalApp.Persistence
{
    public interface IVehicleRepository
    {
        Task<List<Make>> GetMakesWithModels();

        Task<QueryResult<Vehicle>> GetVehicles(VehicleQuery filtersQuery);

        Task AddVehicle(Vehicle vehicle);

        Task<Vehicle> GetVehicle(int id);

        Task<List<Feature>> GetAllFeatures();

    }
}