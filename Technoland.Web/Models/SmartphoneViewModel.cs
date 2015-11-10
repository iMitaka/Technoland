using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Technoland.Web.Models
{
    public class SmartphoneViewModel
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Votes { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
    }
}