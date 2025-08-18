using AutoMapper;
using MonoTest.Models;
using MonoTest.Repository.Interfaces;
using MonoTest.Services.Interfaces;
using MonoTest.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MonoTest.Services
{
    public class VehicleModelService : IVehicleModelService
    {
        private readonly IVehicleMakeRepository _makeRepository;
        private readonly IVehicleModelRepository _modelRepository;
        private readonly IMapper _mapper;

        public VehicleModelService(IVehicleMakeRepository makeRepository, IVehicleModelRepository modelRepository, IMapper mapper)
        {
            _makeRepository = makeRepository;
            _modelRepository = modelRepository;
            _mapper = mapper;
        }

        public async Task AddVehicleModelAsync(VehicleModelViewModel vehicleModelViewModel)
        {
            var vehicleModel = _mapper.Map<VehicleModel>(vehicleModelViewModel);
            await _modelRepository.AddVehicleModelAsync(vehicleModel);
        }

        public async Task DeleteVehicleModelAsync(int? id)
        {
            await _modelRepository.DeleteVehicleModelAsync(id.Value);
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
        public async Task<PageViewModel<VehicleModel>> GetVehicleModelsAsync(int pageNumber, int pageSize, string search, string sortOrder)
        {
            return await _modelRepository.GetVehicleModelsAsync(pageNumber, pageSize, search, sortOrder);
        }
        public async Task UpdateVehicleModelAsync(int? id, VehicleModelViewModel vehicleModel)
        {
            var vehicleModelEntity = _mapper.Map<VehicleModel>(vehicleModel);
            await _modelRepository.UpdateVehicleModelAsync(id.Value, vehicleModelEntity);
        }
        public async Task<PageViewModel<VehicleOverviewViewModel>> GetVehicleOverviewAsync(int pageNumber, int pageSize, string search, string sortOrder)
        {
            return await _modelRepository.GetVehicleOverviewAsync(pageNumber, pageSize, search, sortOrder);
        }
    }
}