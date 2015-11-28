using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Technoland.Web.Models;
using Microsoft.AspNet.Identity;
using LaptopSystem.Web.Models;
using Technoland.Models;

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

        public ActionResult Vote(int id)
        {
            var userId = User.Identity.GetUserId();

            var canVote = !this.Data.Votes.All().Any(x => x.LaptopId == id && x.VotedById == userId);

            if (canVote)
            {
                this.Data.Laptops.GetById(id).Votes.Add(new Vote
                {
                    LaptopId = id,
                    VotedById = userId
                });

                this.Data.SaveChanges();
            }

            var votes = this.Data.Laptops.GetById(id).Votes.Count();

            return Content(votes.ToString());
        }
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult PostComment(SubmitCommentModel commentModel)
        {
            if (ModelState.IsValid)
            {
                var username = this.User.Identity.GetUserName();
                var userId = this.User.Identity.GetUserId();

                this.Data.Comments.Add(new Comment()
                {
                    AuthorId = userId,
                    Content = commentModel.Comment,
                    LaptopId = commentModel.LaptopId,
                });

                this.Data.SaveChanges();

                var viewModel = new CommentViewModel { AuthorUsername = username, Content = commentModel.Comment };
                return PartialView("_CommentPartial", viewModel);
            }

            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, ModelState.Values.First().ToString());
        }
    }
}