using AutoMapper;
using MonoTest.Services.Interfaces;
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
        public readonly IVehicleService _vehicleService;
        public readonly IMapper _mapper;

        public HomeController(IVehicleService vehicleService, IMapper mapper)
        {
            _vehicleService = vehicleService;
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

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            var vehicleOverviewViewModel = await _vehicleService.GetVehicleOverviewAsync();

            if (!String.IsNullOrEmpty(searchString)) 
            { 
                vehicleOverviewViewModel = vehicleOverviewViewModel
                    .Where(v => v.Name.ToLower().Contains(searchString.ToLower())
                             || v.MakeName.ToLower().Contains(searchString.ToLower())
                             || v.Abrv.ToLower().Contains(searchString.ToLower())
                             || v.MakeAbrv.ToLower().Contains(searchString.ToLower()))
                    .ToList();
            }

            switch (sortOrder)
            {
                case "make_desc":
                    vehicleOverviewViewModel = vehicleOverviewViewModel
                        .OrderByDescending(v => v.MakeName).ToList();
                    break;
                case "make":
                    vehicleOverviewViewModel = vehicleOverviewViewModel
                        .OrderBy(v => v.MakeName).ToList();
                    break;
                case "model_name_desc":
                    vehicleOverviewViewModel = vehicleOverviewViewModel
                        .OrderByDescending(v => v.Name).ToList();
                    break;
                case "model_name":
                    vehicleOverviewViewModel = vehicleOverviewViewModel
                        .OrderBy(v => v.Name).ToList();
                    break;
                case "model_abrv_desc":
                    vehicleOverviewViewModel = vehicleOverviewViewModel
                        .OrderByDescending(v => v.Abrv).ToList();
                    break;
                case "model_abrv":
                    vehicleOverviewViewModel = vehicleOverviewViewModel
                        .OrderBy(v => v.Abrv).ToList();
                    break;
                case "abrv_desc":
                    vehicleOverviewViewModel = vehicleOverviewViewModel
                        .OrderByDescending(v => v.MakeAbrv).ToList();
                    break;
                case "abrv":
                    vehicleOverviewViewModel = vehicleOverviewViewModel
                        .OrderBy(v => v.MakeAbrv).ToList();
                    break;
                default:
                    vehicleOverviewViewModel = vehicleOverviewViewModel
                        .OrderBy(v => v.MakeName).ToList();
                    break;
            }


            int pageSize = 5;
            int pageNumber = (page ?? 1);

            return View(vehicleOverviewViewModel.ToPagedList(pageNumber, pageSize));
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