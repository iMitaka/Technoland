using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Technoland.Models
{
    public class Laptop
    {
        private ICollection<Comment> comments;
        private ICollection<Vote> votes;

        public Laptop() 
        {
            this.comments = new HashSet<Comment>();
            this.votes = new HashSet<Vote>();
        }

        public int Id { get; set; }
        public int ManufacturerId { get; set; }
        public string ImageURL { get; set; }
        public decimal Price { get; set; }
        public int HDDSize { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
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

        public virtual ICollection<Comment> Comments 
        {
            get 
            {
                return this.comments;
            }
            set 
            {
                this.comments = value;
            }
        }

        public virtual ICollection<Vote> Votes 
        {
            get 
            {
                return this.votes;
            }
            set 
            {
                this.votes = value;
            }
        }
    }
}
