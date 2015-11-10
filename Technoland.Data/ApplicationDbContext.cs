using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technoland.Models;
using System.Data.Entity;

namespace Technoland.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public IDbSet<Smartphone> Smartphones { get; set; }
        public IDbSet<Comment> Comments { get; set; }
        public IDbSet<Vote> Votes { get; set; }
        public IDbSet<Manufacturer> Manufactures { get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
