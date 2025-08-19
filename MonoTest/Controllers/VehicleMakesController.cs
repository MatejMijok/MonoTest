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
        private readonly IVehicleMakeService _vehicleMakeService;
        private readonly IMapper _mapper;

        public VehicleMakesController(IVehicleMakeService vehicleMakeService, IMapper mapper)
        {
            _vehicleMakeService = vehicleMakeService;
            _mapper= mapper;
        }

        // GET: VehicleMakes
        public async Task<ActionResult> Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.MakeSortParam = sortOrder == "make" ? "make_desc" : "make";
            ViewBag.AbrvSortParam = sortOrder == "abrv" ? "abrv_desc" : "abrv";
            ViewBag.MakeIdSortParam = sortOrder == "makeId" ? "makeId_desc" : "makeId";
            ViewBag.CurrentSort = sortOrder;
            ViewBag.CurrentFilter = searchString ?? currentFilter;

            if (!string.IsNullOrEmpty(searchString))
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            var pagedMakes = await _vehicleMakeService.GetVehicleMakesAsync(pageNumber, pageSize, searchString, sortOrder);

            return View(pagedMakes);
        }

        // GET: VehicleMakes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vehicleMake = await _vehicleMakeService.GetVehicleMakeByIdAsync(id);
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
                var result = await _vehicleMakeService.AddVehicleMakeAsync(vehicleMakeViewModel);
                if (!result)
                {
                    ModelState.AddModelError("", "Unable to create vehicle make. Please try again.");
                    return View(vehicleMakeViewModel);
                }
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
            var vehicleMake = await _vehicleMakeService.GetVehicleMakeByIdAsync(id);
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
                var result = await _vehicleMakeService.UpdateVehicleMakeAsync(vehicleMake.Id, vehicleMake);
                if (!result)
                {
                    ModelState.AddModelError("", "Unable to update vehicle make. Please try again.");
                    return View(vehicleMake);
                }
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
            var vehicleMake = await _vehicleMakeService.GetVehicleMakeByIdAsync(id);
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
            var result = await _vehicleMakeService.DeleteVehicleMakeAsync(id);
            if (!result)
            {
                ModelState.AddModelError("", "Unable to delete vehicle make. Please try again.");
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
