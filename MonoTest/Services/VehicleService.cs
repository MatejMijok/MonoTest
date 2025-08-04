using MonoTest.Models;
using MonoTest.Repository.Interfaces;
using MonoTest.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MonoTest.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleMakeRepository _makeRepository;
        private readonly IVehicleModelRepository _modelRepository;

        public VehicleService()
        {

        }

        public async Task AddVehicleMakeAsync(VehicleMake vehicleMake)
        {
            throw new NotImplementedException();
        }

        public async Task AddVehicleModelAsync(VehicleModel vehicleModel)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteVehicleMakeAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteVehicleModelAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<VehicleMake> GetVehicleMakeByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<VehicleMake>> GetVehicleMakesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<VehicleModel> GetVehicleModelByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<VehicleModel>> GetVehicleModelsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateVehicleMakeAsync(int id, VehicleMake vehicleMake)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateVehicleModelAsync(int id, VehicleModel vehicleModel)
        {
            throw new NotImplementedException();
        }
    }
}