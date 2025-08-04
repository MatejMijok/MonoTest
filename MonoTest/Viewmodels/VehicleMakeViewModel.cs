using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonoTest.ViewModels
{
    public class VehicleMakeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public List<VehicleModelViewModel> VehicleModels { get; set; }
    }
}