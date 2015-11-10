using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Technoland.Web.Models;

namespace Technoland.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            if (this.HttpContext.Cache["HomePageSmartPhones"] == null)
            {
                    var listOfSmartphones = this.Data.Smartphones.All()
                    .OrderByDescending(x => x.Votes.Count())
                    .Take(6)
                    .Select(x => new SmartphoneViewModel
                    {
                        Id = x.Id,
                        Manufacturer = x.Manufacturer.Name,
                        ImageUrl = x.ImageURL,
                        Model = x.Model,
                        Price = x.Price,
                        Votes = x.Votes.Count(),
                    });
                    this.HttpContext.Cache.Add("HomePageSmartPhones", listOfSmartphones.ToList(), null, DateTime.Now.AddHours(1), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Default, null);
            }

            return View(this.HttpContext.Cache["HomePageSmartPhones"]);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}