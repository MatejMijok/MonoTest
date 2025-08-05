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
            var vehicleMake = _mapper.Map<VehicleMake>(vehicleMakeViewModel);
            await _makeRepository.AddVehicleMakeAsync(vehicleMake);
        }

        public async Task AddVehicleModelAsync(VehicleModelViewModel vehicleModelViewModel)
        {
            var vehicleModel = _mapper.Map<VehicleModel>(vehicleModelViewModel);
            await _modelRepository.AddVehicleModelAsync(vehicleModel);
        }

        public async Task DeleteVehicleMakeAsync(int? id)
        {
            await _makeRepository.DeleteVehicleMakeAsync(id.Value);
        }

        public async Task DeleteVehicleModelAsync(int? id)
        {
            await _modelRepository.DeleteVehicleModelAsync(id.Value);
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
            var vehicleModel = await _modelRepository.GetVehicleModelByIdAsync(id.Value);
            return _mapper.Map<VehicleModelViewModel>(vehicleModel);
        }

        public async Task<IEnumerable<VehicleModelViewModel>> GetVehicleModelsAsync()
        {
            var vehicleModel = await _modelRepository.GetVehicleModelsAsync();
            return _mapper.Map<IEnumerable<VehicleModelViewModel>>(vehicleModel);
        }

        public async Task UpdateVehicleMakeAsync(int? id, VehicleMakeViewModel vehicleMake)
        {
            var vehicleMakeEntity = _mapper.Map<VehicleMake>(vehicleMake);
            await _makeRepository.UpdateVehicleMakeAsync(id.Value, vehicleMakeEntity);
        }

        public async Task UpdateVehicleModelAsync(int? id, VehicleModelViewModel vehicleModel)
        {
            var vehicleModelEntity = _mapper.Map<VehicleModel>(vehicleModel);
            await _modelRepository.UpdateVehicleModelAsync(id.Value, vehicleModelEntity);
        }
    }
}