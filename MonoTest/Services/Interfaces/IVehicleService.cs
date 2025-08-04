using MonoTest.Models;
using MonoTest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoTest.Services.Interfaces
{
    public interface IVehicleService
    {
        Task<IEnumerable<VehicleMakeViewModel>> GetVehicleMakesAsync();
        Task<VehicleMakeViewModel> GetVehicleMakeByIdAsync(int? id);
        Task AddVehicleMakeAsync(VehicleMakeViewModel vehicleMakeViewModel);
        Task UpdateVehicleMakeAsync(int? id, VehicleMakeViewModel vehicleMakeViewModel);
        Task DeleteVehicleMakeAsync(int? id);
        Task<IEnumerable<VehicleModelViewModel>> GetVehicleModelsAsync();
        Task<VehicleModelViewModel> GetVehicleModelByIdAsync(int? id);
        Task AddVehicleModelAsync(VehicleModelViewModel vehicleModelViewModel);
        Task UpdateVehicleModelAsync(int? id, VehicleModelViewModel vehicleModelViewModel);
        Task DeleteVehicleModelAsync(int? id);
    }
}
