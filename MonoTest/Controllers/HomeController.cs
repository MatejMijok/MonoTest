using AutoMapper;
using MonoTest.Services.Interfaces;
using MonoTest.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MonoTest.Controllers
{
    public class HomeController : Controller
    {
        public readonly IVehicleMakeService _vehicleMakeService;
        public readonly IVehicleModelService _vehicleModelService;
        public readonly IMapper _mapper;

        public HomeController(IVehicleMakeService vehicleMakeService, IVehicleModelService vehicleModelService, IMapper mapper)
        {
            _vehicleMakeService = vehicleMakeService;
            _vehicleModelService = vehicleModelService;
            _mapper = mapper;
        }
        public async Task<ActionResult> Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.MakeSortParam = sortOrder == "make" ? "make_desc" : "make";
            ViewBag.ModelNameSortParam = sortOrder == "model_name" ? "model_name_desc" : "model_name";
            ViewBag.ModelAbrvSortParam = sortOrder == "model_abrv" ? "model_abrv_desc" : "model_abrv";
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

            var vehicleOverviewViewModel = await _vehicleModelService.GetVehicleOverviewAsync(pageNumber, pageSize, searchString, sortOrder);

            return View(vehicleOverviewViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}