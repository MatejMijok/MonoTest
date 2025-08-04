using AutoMapper;
using MonoTest.Models;
using MonoTest.Repository.Interfaces;
using MonoTest.Services.Interfaces;
using MonoTest.ViewModels;
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
        private readonly IMapper _mapper;

        public VehicleService(IVehicleMakeRepository makeRepository, IVehicleModelRepository modelRepository, IMapper mapper)
        {
            _makeRepository = makeRepository;
            _modelRepository = modelRepository;
            _mapper = mapper;
        }

        public async Task AddVehicleMakeAsync(VehicleMakeViewModel vehicleMakeViewModel)
        {
            throw new NotImplementedException();
        }

        public async Task AddVehicleModelAsync(VehicleModelViewModel vehicleModelViewModel)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteVehicleMakeAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteVehicleModelAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task<VehicleMakeViewModel> GetVehicleMakeByIdAsync(int? id)
        {
            var vehicleMake = await _makeRepository.GetVehicleMakeByIdAsync(id.Value);
            return _mapper.Map<VehicleMakeViewModel>(vehicleMake);
        }

        public async Task<IEnumerable<VehicleMakeViewModel>> GetVehicleMakesAsync()
        {
            var makes = await _makeRepository.GetVehicleMakesAsync();
            return _mapper.Map<IEnumerable<VehicleMakeViewModel>>(makes);
        }

        public async Task<VehicleModelViewModel> GetVehicleModelByIdAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<VehicleModelViewModel>> GetVehicleModelsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateVehicleMakeAsync(int? id, VehicleMakeViewModel vehicleMake)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateVehicleModelAsync(int? id, VehicleModelViewModel vehicleModel)
        {
            throw new NotImplementedException();
        }
    }
}