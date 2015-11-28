using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Technoland.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string AuthorId { get; set; }

        public string Content { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public int? SmartphoneId { get; set; }

        public virtual Smartphone Smartphone { get; set; }

        public int? LaptopId { get; set; }
        public virtual Laptop Laptop { get; set; }
    }
}
