using MonoTest.Models;
using MonoTest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoTest.Repository.Interfaces
{
    public interface IVehicleModelRepository
    {
        Task<IEnumerable<VehicleModel>> GetVehicleModelsAsync();
        Task<PageViewModel<VehicleModel>> GetVehicleModelsAsync(int pageNumber, int pageSize, string search, string sortOrder);
        Task<PageViewModel<VehicleOverviewViewModel>> GetVehicleOverviewAsync(int pageNumber, int pageSize, string search, string sortOrder);
        Task<VehicleModel> GetVehicleModelByIdAsync(int id);
        Task AddVehicleModelAsync(VehicleModel vehicleModel);
        Task UpdateVehicleModelAsync(int id, VehicleModel vehicleModel);
        Task DeleteVehicleModelAsync(int id);
    }
}
