using MonoTest.Models;
using MonoTest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoTest.Services.Interfaces
{
    public interface IVehicleMakeService
    {
        Task<IEnumerable<VehicleMakeViewModel>> GetVehicleMakesAsync();
        Task<PageViewModel<VehicleMake>> GetVehicleMakesAsync(int pageNumber, int pageSize, string search, string sortOrder);
        Task<VehicleMakeViewModel> GetVehicleMakeByIdAsync(int? id);
        Task AddVehicleMakeAsync(VehicleMakeViewModel vehicleMakeViewModel);
        Task UpdateVehicleMakeAsync(int? id, VehicleMakeViewModel vehicleMakeViewModel);
        Task DeleteVehicleMakeAsync(int? id);
    }
}
