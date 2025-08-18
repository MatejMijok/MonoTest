using MonoTest.Data;
using MonoTest.Models;
using MonoTest.Repository.Interfaces;
using MonoTest.ViewModels;
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
        public async Task<PageViewModel<VehicleModel>> GetVehicleModelsAsync(int pageNumber, int pageSize, string search, string sortOrder)
        {
            var query = _context.VehicleModels.AsQueryable();

            if (search != null) 
            { 
                query = query.Where(vm => vm.Name.Contains(search.ToLower()) || 
                                        vm.Abrv.Contains(search.ToLower()) || 
                                        vm.MakeId.ToString().Contains(search));
            }

            switch (sortOrder) 
            {
                case "model":
                    query = query.OrderBy(vm => vm.Name);
                    break;
                case "model_desc":
                    query = query.OrderByDescending(vm => vm.Name);
                    break;
                case "abrv":
                    query = query.OrderBy(vm => vm.Abrv);
                    break;
                case "abrv_desc":
                    query = query.OrderByDescending(vm => vm.Abrv);
                    break;
                case "makeId":
                    query = query.OrderBy(vm => vm.MakeId);
                    break;
                case "makeId_desc":
                    query = query.OrderByDescending(vm => vm.MakeId);
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

            return new PageViewModel<VehicleModel>
            {
                Items = items,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
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