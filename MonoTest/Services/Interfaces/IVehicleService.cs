using MonoTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoTest.Services.Interfaces
{
    internal interface IVehicleService
    {
        Task<IEnumerable<VehicleMake>> GetVehicleMakesAsync();
        Task<VehicleMake> GetVehicleMakeByIdAsync(int id);
        Task AddVehicleMakeAsync(VehicleMake vehicleMake);
        Task UpdateVehicleMakeAsync(int id, VehicleMake vehicleMake);
        Task DeleteVehicleMakeAsync(int id);
        Task<IEnumerable<VehicleModel>> GetVehicleModelsAsync();
        Task<VehicleModel> GetVehicleModelByIdAsync(int id);
        Task AddVehicleModelAsync(VehicleModel vehicleModel);
        Task UpdateVehicleModelAsync(int id, VehicleModel vehicleModel);
        Task DeleteVehicleModelAsync(int id);
    }
}
