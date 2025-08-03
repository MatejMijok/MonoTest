using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonoTest.Models
{
    public class VehicleMake
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public virtual ICollection<VehicleModel> VehicleModels { get; set; }
    }
}