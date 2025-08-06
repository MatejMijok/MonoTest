using AutoMapper;
using MonoTest.Services.Interfaces;
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
        public readonly IVehicleService _vehicleService;
        public readonly IMapper _mapper;

        public HomeController(IVehicleService vehicleService, IMapper mapper)
        {
            _vehicleService = vehicleService;
            _mapper = mapper;
        }
        public async Task<ActionResult> Index(string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            var vehicleOverviewViewModel = await _vehicleService.GetVehicleOverviewAsync();

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