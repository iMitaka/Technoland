using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Technoland.Models
{
    public class Manufacturer
    {
        private ICollection<Laptop> laptops;
        private ICollection<Smartphone> smartphones;

        public Manufacturer()
        {
            this.smartphones = new HashSet<Smartphone>();
            this.laptops = new HashSet<Laptop>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool HasLaptops { get; set; }
        public bool HasSmartphones { get; set; }

        public virtual ICollection<Smartphone> Smartphones 
        {
            get 
            {
                return this.smartphones;
            }
            set 
            {
                this.smartphones = value;
            }
        }

        public ICollection<Laptop> Laptops 
        {
            get 
            {
                return this.laptops;
            }
            set 
            {
                this.laptops = value;
            }
        }
       
    }
}
