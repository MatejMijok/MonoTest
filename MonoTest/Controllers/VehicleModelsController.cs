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
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MonoTest.Controllers
{
    [Authorize(Roles = "admin")]
    public class VehicleModelsController : Controller
    {
        private readonly IVehicleService _vehicleService;
        private readonly IMapper _mapper;

        public VehicleModelsController(IVehicleService vehicleService, IMapper mapper)
        {
            _vehicleService = vehicleService;
            _mapper = mapper;
        }

        // GET: VehicleModels
        public async Task<ActionResult> Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.MakeSortParam = sortOrder == "model" ? "model_desc" : "model";
            ViewBag.AbrvSortParam = sortOrder == "abrv" ? "abrv_desc" : "abrv";
            ViewBag.MakeIdSortParam = sortOrder == "makeId" ? "makeId_desc" : "abrv";
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

            var models = await _vehicleService.GetVehicleModelsAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                models = models
                    .Where(m => m.Name.ToLower().Contains(searchString.ToLower())
                             || m.Abrv.ToLower().Contains(searchString.ToLower()))
                    .ToList();
            }

            switch (sortOrder) 
            {
                case "model":
                    models = models.OrderBy(m => m.Name).ToList();
                    break;
                case "model_desc":
                    models = models.OrderByDescending(m => m.Name).ToList();
                    break;
                case "abrv":
                    models = models.OrderBy(m => m.Abrv).ToList();
                    break;
                case "abrv_desc":
                    models = models.OrderByDescending(m => m.Abrv).ToList();
                    break;
                case "makeId":
                    models = models.OrderByDescending(m => m.MakeId).ToList();
                    break;
                case "makeId_desc":
                    models = models.OrderByDescending(m => m.MakeId).ToList();
                    break;
                default:
                    models = models.OrderBy(m => m.Name).ToList();
                    break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            return View(models.ToPagedList(pageNumber, pageSize));
        }

        // GET: VehicleModels/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vehicleModel = await _vehicleService.GetVehicleModelByIdAsync(id);
            if (vehicleModel == null)
            {
                return HttpNotFound();
            }
            return View(vehicleModel);
        }

        // GET: VehicleModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehicleModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Abrv,MakeId")] VehicleModelViewModel vehicleModel)
        {
            if (ModelState.IsValid)
            {
                await _vehicleService.AddVehicleModelAsync(vehicleModel);
                return RedirectToAction("Index");
            }

            return View(vehicleModel);
        }

        // GET: VehicleModels/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vehicleModel = await _vehicleService.GetVehicleModelByIdAsync(id);
            if (vehicleModel == null)
            {
                return HttpNotFound();
            }
            return View(vehicleModel);
        }

        // POST: VehicleModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Abrv,MakeId")] VehicleModelViewModel vehicleModel)
        {
            if (ModelState.IsValid)
            {
                await _vehicleService.UpdateVehicleModelAsync(vehicleModel.Id,vehicleModel);
                return RedirectToAction("Index");
            }
            return View(vehicleModel);
        }

        // GET: VehicleModels/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vehicleModel = await _vehicleService.GetVehicleModelByIdAsync(id);
            if (vehicleModel == null)
            {
                return HttpNotFound();
            }
            return View(vehicleModel);
        }

        // POST: VehicleModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _vehicleService.DeleteVehicleModelAsync(id);
            return RedirectToAction("Index");
        }
    }
}
