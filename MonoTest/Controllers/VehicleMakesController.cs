using AutoMapper;
using MonoTest.Data;
using MonoTest.Models;
using MonoTest.Services.Interfaces;
using MonoTest.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace MonoTest.Controllers
{
    [Authorize(Roles = "admin")]
    public class VehicleMakesController : Controller
    {
        private readonly IVehicleService _vehicleService;
        private readonly IMapper _mapper;

        public VehicleMakesController(IVehicleService vehicleService, IMapper mapper)
        {
            _vehicleService = vehicleService;
            _mapper = mapper;
        }

        // GET: VehicleMakes
        public async Task<ActionResult> Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.MakeSortParam = sortOrder == "make" ? "make_desc" : "make";
            ViewBag.AbrvSortParam = sortOrder == "abrv" ? "abrv_desc" : "abrv";
            ViewBag.CurrentSort = sortOrder;
            ViewBag.CurrentFilter = searchString ?? currentFilter;

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            var makes = await _vehicleService.GetVehicleMakesAsync();


            if (!String.IsNullOrEmpty(searchString))
            {
                makes = makes
                    .Where(m => m.Name.ToLower().Contains(searchString.ToLower())
                             || m.Abrv.ToLower().Contains(searchString.ToLower()))
                    .ToList();
            }

            switch (sortOrder) 
            {
                case "make":
                    makes = makes.OrderBy(m => m.Name).ToList();
                    break;
                case "make_desc":
                    makes = makes.OrderByDescending(m => m.Name).ToList();
                    break;  
                case "abrv":
                    makes = makes.OrderBy(m => m.Abrv).ToList();
                    break;
                case "abrv_desc":
                    makes = makes.OrderByDescending(m => m.Abrv).ToList();
                    break;
                default:
                    makes = makes.OrderBy(m => m.Name).ToList();
                    break;
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            return View(makes.ToPagedList(pageNumber, pageSize));
        }

        // GET: VehicleMakes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vehicleMake = await _vehicleService.GetVehicleMakeByIdAsync(id);
            if (vehicleMake == null)
            {
                return HttpNotFound();
            }
            return View(vehicleMake);
        }

        // GET: VehicleMakes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehicleMakes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Abrv")] VehicleMakeViewModel vehicleMakeViewModel)
        {
            if (ModelState.IsValid)
            {
                await _vehicleService.AddVehicleMakeAsync(vehicleMakeViewModel);
                return RedirectToAction("Index");
            }

            return View(vehicleMakeViewModel);
        }

        // GET: VehicleMakes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vehicleMake = await _vehicleService.GetVehicleMakeByIdAsync(id);
            if (vehicleMake == null)
            {
                return HttpNotFound();
            }
            return View(vehicleMake);
        }

        // POST: VehicleMakes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Abrv")] VehicleMakeViewModel vehicleMake)
        {
            if (ModelState.IsValid)
            {
                await _vehicleService.UpdateVehicleMakeAsync(vehicleMake.Id, vehicleMake);
                return RedirectToAction("Index");
            }
            return View(vehicleMake);
        }

        // GET: VehicleMakes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vehicleMake = await _vehicleService.GetVehicleMakeByIdAsync(id);
            if (vehicleMake == null)
            {
                return HttpNotFound();
            }
            return View(vehicleMake);
        }

        // POST: VehicleMakes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _vehicleService.DeleteVehicleMakeAsync(id);
            return RedirectToAction("Index");
        }
    }
}
