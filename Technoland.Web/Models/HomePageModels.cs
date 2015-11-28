using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Technoland.Web.Models
{
    public class HomePageModels
    {
        public IEnumerable<LaptopViewModel> LaptopViewModel { get; set; }
        public IEnumerable<SmartphoneViewModel> SmartphoneViewModel { get; set; }
    }
}