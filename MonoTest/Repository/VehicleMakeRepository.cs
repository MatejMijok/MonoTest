using MonoTest.Data;
using MonoTest.Models;
using MonoTest.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MonoTest.Repository
{
    public class VehicleMakeRepository : IVehicleMakeRepository
    {
        private readonly MonoTestContext _context;

        public VehicleMakeRepository(MonoTestContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VehicleMake>> GetVehicleMakesAsync() 
        {
            return await _context.VehicleMakes.ToListAsync();
        }
        public async Task<VehicleMake> GetVehicleMakeByIdAsync(int id)
        { 
            return await _context.VehicleMakes.FindAsync(id);
        }
        public async Task AddVehicleMakeAsync(VehicleMake vehicleMake) 
        {
            _context.VehicleMakes.Add(vehicleMake);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateVehicleMakeAsync(int id, VehicleMake vehicleMake)
        { 
            _context.Entry(vehicleMake).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
       public async Task DeleteVehicleMakeAsync(int id)
        { 
            var make = await _context.VehicleMakes.FindAsync(id);
            var models = await _context.VehicleModels.Where(vm => vm.MakeId == id).ToListAsync();

            _context.VehicleModels.RemoveRange(models);

            _context.VehicleMakes.Remove(make);

            await _context.SaveChangesAsync();
        }
    }
}