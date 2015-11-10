using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Technoland.Models
{
    public class Manufacturer
    {
        private ICollection<Smartphone> smartphones;
        public Manufacturer()
        {
            this.smartphones = new HashSet<Smartphone>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

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
       
    }
}
