using MonoTest.Models;
using MonoTest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoTest.Repository.Interfaces
{
    public interface IVehicleMakeRepository
    {
        Task<IEnumerable<VehicleMake>> GetVehicleMakesAsync();
        Task<PageViewModel<VehicleMake>> GetVehicleMakesAsync(int pageNumber, int pageSize, string search, string sortOrder);
        Task<VehicleMake> GetVehicleMakeByIdAsync(int id);
        Task AddVehicleMakeAsync(VehicleMake vehicleMake);
        Task UpdateVehicleMakeAsync(int id, VehicleMake vehicleMake);
        Task DeleteVehicleMakeAsync(int id);
    }
}
