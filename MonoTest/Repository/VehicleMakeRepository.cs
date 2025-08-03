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
            _context.VehicleMakes.Remove(await GetVehicleMakeByIdAsync(id));
            await _context.SaveChangesAsync();
        }
    }
}