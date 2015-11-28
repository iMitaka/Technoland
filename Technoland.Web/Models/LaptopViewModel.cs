using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Technoland.Web.Models
{
    public class LaptopViewModel
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Votes { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public string ProcessorInfo { get; set; }
        public string VideoCardInfo { get; set; }
        public string RAMInfo { get; set; }
        public string HDDInfo { get; set; }    
    }
}