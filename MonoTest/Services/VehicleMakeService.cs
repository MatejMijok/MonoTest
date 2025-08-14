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
    public class VehicleMakeService : IVehicleMakeService
    {
        private readonly IVehicleMakeRepository _makeRepository;
        private readonly IVehicleModelRepository _modelRepository;
        private readonly IMapper _mapper;

        public VehicleMakeService(IVehicleMakeRepository makeRepository, IVehicleModelRepository modelRepository, IMapper mapper)
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

        public async Task DeleteVehicleMakeAsync(int? id)
        {
            await _makeRepository.DeleteVehicleMakeAsync(id.Value);
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

        public async Task UpdateVehicleMakeAsync(int? id, VehicleMakeViewModel vehicleMake)
        {
            var vehicleMakeEntity = _mapper.Map<VehicleMake>(vehicleMake);
            await _makeRepository.UpdateVehicleMakeAsync(id.Value, vehicleMakeEntity);
        }
    }
}