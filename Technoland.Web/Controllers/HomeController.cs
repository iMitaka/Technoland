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
             var model = new HomePageModels();

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

            if (this.HttpContext.Cache["HomePageLaptops"] == null)
            {
                var listOfLaptops = this.Data.Laptops.All()
                .OrderByDescending(x => x.Votes.Count())
                .Take(6)
                .Select(x => new LaptopViewModel
                {
                    Id = x.Id,
                    Manufacturer = x.Manufacturer.Name,
                    ImageUrl = x.ImageURL,
                    Model = x.Model,
                    Price = x.Price,
                    Votes = x.Votes.Count(),
                    HDDInfo = x.HDDSize + "GB HDD",
                    ProcessorInfo = x.CPUManufacturer + " " + x.CPUModel,
                    RAMInfo = x.RAM + "GB" + x.RAMMemoryType,
                    VideoCardInfo = x.VideoCardManufacturer + " " + x.VideoCardModel
                });
                this.HttpContext.Cache.Add("HomePageLaptops", listOfLaptops.ToList(), null, DateTime.Now.AddHours(1), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Default, null);
            }

            model.SmartphoneViewModel = (IEnumerable<SmartphoneViewModel>)this.HttpContext.Cache["HomePageSmartPhones"];
            model.LaptopViewModel = (IEnumerable<LaptopViewModel>)this.HttpContext.Cache["HomePageLaptops"];

            //return View(this.HttpContext.Cache["HomePageSmartPhones"]);
            return View(model);
        }
    }
}