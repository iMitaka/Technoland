using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Technoland.Web.Models;
using Microsoft.AspNet.Identity;

namespace Technoland.Web.Controllers
{
    public class LaptopController : BaseController
    {
        // GET: Laptop
        public ActionResult Details(int id)
        {
            var userId = User.Identity.GetUserId();

            var laptop = this.Data.Laptops.All().Where(l => l.Id == id)
                .Select(l => new LaptopDetailsViewModel 
                { 
                BatteryInformation = l.BatteryInformation,
                Camera = l.Camera,
                RAM = l.RAM,
                RAMMemoryType = l.RAMMemoryType,
                Color = l.Color,
                Comments = l.Comments.Select(y => new CommentViewModel { AuthorUsername = y.Author.UserName, Content = y.Content }),
                SSD = l.SSD,
                HDDSize = l.HDDSize,
                IPS = l.IPS,
                OS = l.OS,
                ConnectionsInformation = l.ConnectionsInformation,
                CPUFrequency = l.CPUFrequency,
                CPUManufacturer = l.CPUManufacturer,
                CPUModel = l.CPUModel,
                Id = l.Id,
                ImageURL = l.ImageURL,
                Interfaces = l.Interfaces,
                Manufacturer = l.Manufacturer.Name,
                Model = l.Model,
                Price = l.Price,
                VideoCardManufacturer = l.VideoCardManufacturer,
                VideoCardModel = l.VideoCardModel,
                VideoMemory = l.VideoMemory,
                Votes = l.Votes.Count(),
                UserCanVote = !l.Votes.Any(vote => vote.VotedById == userId),
                }).FirstOrDefault();

            return View(laptop);
        }
    }
}