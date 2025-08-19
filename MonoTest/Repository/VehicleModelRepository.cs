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

            if (!string.IsNullOrEmpty(search)) 
            { 
                query = query.Where(vm => vm.Name.Contains(search.ToLower()) || 
                                        vm.Abrv.Contains(search.ToLower()) ||
                                        vm.VehicleMakeId.ToString().Contains(search));
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
                    query = query.OrderBy(vm => vm.VehicleMakeId);
                    break;
                case "makeId_desc":
                    query = query.OrderByDescending(vm => vm.VehicleMakeId);
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
        public async Task<PageViewModel<VehicleOverviewViewModel>> GetVehicleOverviewAsync(int pageNumber, int pageSize, string search, string sortOrder) 
        { 
            var query = _context.VehicleModels.Include(vm => vm.VehicleMake).AsQueryable();

            if (!string.IsNullOrEmpty(search)) 
            { 
                query = query.Where(vm => vm.Name.Contains(search.ToLower()) || 
                                        vm.Abrv.Contains(search.ToLower()) ||
                                        vm.VehicleMake.Name.Contains(search.ToLower()) ||
                                        vm.VehicleMake.Abrv.Contains(search.ToLower()));
            }

            switch (sortOrder) 
            {
                case "make":
                    query = query.OrderBy(vm => vm.VehicleMake.Name);
                    break;
                case "make_desc":
                    query = query.OrderByDescending(vm => vm.VehicleMake.Name);
                    break;
                case "model_name":
                    query = query.OrderBy(vm => vm.Name);
                    break;
                case "model_name_desc":
                    query = query.OrderByDescending(vm => vm.Name);
                    break;
                case "model_abrv":
                    query = query.OrderBy(vm => vm.Abrv);
                    break;
                case "model_abrv_desc":
                    query = query.OrderByDescending(vm => vm.Abrv);
                    break;
                case "abrv":
                    query = query.OrderBy(vm => vm.VehicleMake.Abrv);
                    break;
                case "abrv_desc":
                    query = query.OrderByDescending(vm => vm.VehicleMake.Abrv);
                    break;
                default:
                    query = query.OrderBy(vm => vm.VehicleMake.Name);
                    break;
            }

            var totalCount = await query.CountAsync();

            var itemEntities = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var items = itemEntities.Select(vm => new VehicleOverviewViewModel
            {
                Name = vm.Name,
                Abrv = vm.Abrv,
                MakeName = vm.VehicleMake.Name,
                MakeAbrv = vm.VehicleMake.Abrv
            }).ToList();

            return new PageViewModel<VehicleOverviewViewModel>
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
        public async Task<bool> AddVehicleModelAsync(VehicleModel vehicleModel)
        {
            try 
            {
                _context.VehicleModels.Add(vehicleModel);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) 
            {
                return false;
            }
        }
        public async Task<bool> UpdateVehicleModelAsync(int id, VehicleModel vehicleModel)
        {
            try 
            {
                _context.Entry(vehicleModel).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) 
            {
                return false;
            }

        }
        public async Task<bool> DeleteVehicleModelAsync(int id)
        {
            try
            {
                _context.VehicleModels.Remove(await GetVehicleModelByIdAsync(id));
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) 
            {
                return false;
            }

        }
    }
}