using MonoTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoTest.Repository.Interfaces
{
    internal interface IVehicleModelRepository
    {
        Task<IEnumerable<VehicleModel>> GetVehicleModelsAsync();
        Task<VehicleModel> GetVehicleModelByIdAsync(int id);
        Task AddVehicleModelAsync(VehicleModel vehicleModel);
        Task UpdateVehicleModelAsync(int id, VehicleModel vehicleModel);
        Task DeleteVehicleModelAsync(int id);
    }
}
