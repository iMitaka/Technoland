using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Technoland.Models
{
    public class Vote
    {
        public int Id { get; set; }

        public string VotedById { get; set; }

        public virtual ApplicationUser VotedBy { get; set; }

        public int? SmartphoneId { get; set; }

        public virtual Smartphone Smartphone { get; set; }

        public int? LaptopId { get; set; }
        public virtual Laptop Laptop { get; set; }
    }
}
