using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Technoland.Web.Models
{
    public class LaptopDetailsViewModel
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string ImageURL { get; set; }
        public decimal Price { get; set; }
        public int HDDSize { get; set; }
        public string Model { get; set; }
        public int RAM { get; set; }
        public string RAMMemoryType { get; set; }
        public string VideoCardManufacturer { get; set; }
        public string VideoCardModel { get; set; }
        public int VideoMemory { get; set; }
        public string CPUManufacturer { get; set; }
        public string CPUModel { get; set; }
        public double CPUFrequency { get; set; }
        public string OS { get; set; }
        public bool Camera { get; set; }
        public string Color { get; set; }
        public string ConnectionsInformation { get; set; }
        public bool SSD { get; set; }
        public bool IPS { get; set; }
        public string Interfaces { get; set; }
        public string BatteryInformation { get; set; }
        public IEnumerable<CommentViewModel> Comments { get; set; }
        public bool UserCanVote { get; set; }
        public int Votes { get; set; }
    }
}