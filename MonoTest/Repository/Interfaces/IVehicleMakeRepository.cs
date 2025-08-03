using MonoTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoTest.Repository.Interfaces
{
    internal interface IVehicleMakeRepository
    {
        Task<IEnumerable<VehicleMake>> GetVehicleMakesAsync();
        Task<VehicleMake> GetVehicleMakeByIdAsync(int id);
        Task AddVehicleMakeAsync(VehicleMake vehicleMake);
        Task UpdateVehicleMakeAsync(int id, VehicleMake vehicleMake);
        Task DeleteVehicleMakeAsync(int id);
    }
}
