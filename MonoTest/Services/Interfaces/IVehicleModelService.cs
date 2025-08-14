using MonoTest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoTest.Services.Interfaces
{
    public interface IVehicleModelService
    {
        Task<IEnumerable<VehicleModelViewModel>> GetVehicleModelsAsync();
        Task<VehicleModelViewModel> GetVehicleModelByIdAsync(int? id);
        Task AddVehicleModelAsync(VehicleModelViewModel vehicleModelViewModel);
        Task UpdateVehicleModelAsync(int? id, VehicleModelViewModel vehicleModelViewModel);
        Task DeleteVehicleModelAsync(int? id);
        Task<IEnumerable<VehicleOverviewViewModel>> GetVehicleOverviewAsync();
    }
}
