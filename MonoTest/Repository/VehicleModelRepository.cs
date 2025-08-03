using MonoTest.Data;
using MonoTest.Models;
using MonoTest.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using System.Web;

namespace MonoTest.Repository
{
    public class VehicleModelRepository : IVehicleModelRepository
    {
        private readonly MonoTestContext _context;

        public VehicleModelRepository(MonoTestContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VehicleModel>> GetVehicleModelsAsync()
        {
            return await _context.VehicleModels.ToListAsync();
        }
        public async Task<VehicleModel> GetVehicleModelByIdAsync(int id) 
        { 
            return await _context.VehicleModels.FindAsync(id);
        }
        public async Task AddVehicleModelAsync(VehicleModel vehicleModel) 
        { 
            _context.VehicleModels.Add(vehicleModel);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateVehicleModelAsync(int id, VehicleModel vehicleModel)
        { 
            _context.Entry(vehicleModel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteVehicleModelAsync(int id) 
        { 
            _context.VehicleModels.Remove(await GetVehicleModelByIdAsync(id));
            await _context.SaveChangesAsync();
        }
    }
}