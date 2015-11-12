using Technoland.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Technoland.Data
{
    public interface IUowData
    {
        IRepository<Smartphone> Smartphones { get; }

        IRepository<Manufacturer> Manufacturers { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Vote> Votes { get; }

        IRepository<ApplicationUser> ApplicationUsers { get; }

        int SaveChanges();
    }
}
