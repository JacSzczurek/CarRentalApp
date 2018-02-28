using System.Collections.Generic;
using System.Threading.Tasks;
using CarRentalApp.Core.Model;

namespace CarRentalApp.Persistence
{
    public interface IVehicleRepository
    {
        Task<List<Make>> GetMakesWithModels();

        Task<List<Vehicle>> GetAllVehicles();
    }
}