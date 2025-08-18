using MonoTest.Data;
using MonoTest.Models;
using MonoTest.Repository.Interfaces;
using MonoTest.ViewModels;
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

        public async Task<PageViewModel<VehicleMake>> GetVehicleMakesAsync(int pageNumber, int pageSize, string search, string sortOrder) 
        {
            var query = _context.VehicleMakes.AsQueryable();

            if (search != null) {
                query = query.Where(vm => vm.Name.Contains(search.ToLower()) || vm.Abrv.Contains(search.ToLower()));
            }

            switch (sortOrder) 
            {
                case "make":
                    query = query.OrderBy(vm => vm.Name);
                    break;
                case "make_desc":
                    query = query.OrderByDescending(vm => vm.Name);
                    break;
                case "abrv":
                    query = query.OrderBy(vm => vm.Abrv);
                    break;
                case "abrv_desc":
                    query = query.OrderByDescending(vm => vm.Abrv);
                    break;
                case "makeId":
                    query = query.OrderBy(vm => vm.Id);
                    break;
                case "makeId_desc":
                    query = query.OrderByDescending(vm => vm.Id);
                    break;
                default:
                    query = query.OrderBy(vm => vm.Name);
                    break;
            }

            var totalCount = await query.CountAsync();

            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PageViewModel<VehicleMake>
            {
                Items = items,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
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
            var models = await _context.VehicleModels.Where(vm => vm.VehicleMakeId == id).ToListAsync();

            _context.VehicleModels.RemoveRange(models);

            _context.VehicleMakes.Remove(make);

            await _context.SaveChangesAsync();
        }
    }
}