using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Net.Http;
using Technoland.Web.Models;
using Technoland.Models;
using LaptopSystem.Web.Models;

namespace Technoland.Web.Controllers
{
    public class SmartphonesController : BaseController
    {
        // GET: Smartphone
        public ActionResult Details(int id)
        {
            var userId = User.Identity.GetUserId();

            var viewModel = this.Data.Smartphones.All().Where(x => x.Id == id)
                .Select(x => new SmartphoneDetailsViewModel
                {
                    Id = x.Id,
                    Comments = x.Comments.Select(y => new CommentViewModel { AuthorUsername = y.Author.UserName, Content = y.Content }),
                    ImageURL = x.ImageURL,
                    Manufacturer = x.Manufacturer.Name,
                    Model = x.Model,
                    ScreenSize = x.ScreenSize,
                    Price = x.Price,
                    Weight = x.Weight,
                    UserCanVote = !x.Votes.Any(pesho => pesho.VotedById == userId),
                    Votes = x.Votes.Count(),
                    additionalCameraFunctions = x.additionalCameraFunctions,
                    GPRS = x.GPRS,
                    BatteryCappacity = x.BatteryCappacity,
                    HSDPA = x.HSDPA,
                    ScreenColors = x.ScreenColors,
                    ScreenProtection = x.ScreenProtection,
                    ScreenType = x.ScreenType,
                    SecondaryCameraPixels = x.SecondaryCameraPixels,
                    Senzors = x.Senzors,
                    SIMType = x.SIMType,
                    StereoSound = x.StereoSound,
                    GPSInformation = x.GPSInformation,
                    HSUPA = x.HSDPA,
                    OS = x.OS,
                    USB = x.USB,
                    VideoFPS = x.VideoFPS,
                    connection2G = x.connection2G,
                    connection3G = x.connection3G,
                    connection4G = x.connection4G,
                    CameraPixels = x.CameraPixels,
                    CameraResolution = x.CameraResolution,
                    Chipset = x.Chipset,
                    Cores = x.Cores,
                    EDGE = x.EDGE,
                    DeffoultBrowser = x.DeffoultBrowser,
                    HoursListenOfMusic = x.HoursListenOfMusic,
                    BattryType = x.BattryType,
                    BluetoothInfo = x.BluetoothInfo,
                    GPU = x.GPU,
                    externalMomory = x.externalMomory,
                    internalMemory = x.internalMemory,
                    Frequency = x.Frequency,
                    HoursOfTalk = x.HoursOfTalk,
                    MessagesInfo = x.MessagesInfo,
                    Multitouch = x.Multitouch,
                    RAM = x.RAM,
                    RAMMemoryType = x.RAMMemoryType,
                    Resolution = x.Resolution,
                    VideoResolutionP = x.VideoResolutionP,
                    WLANInfo = x.WLANInfo,
                }).FirstOrDefault();

            return View(viewModel);
        }
        public ActionResult Vote(int id)
        {
            var userId = User.Identity.GetUserId();

            var canVote = !this.Data.Votes.All().Any(x => x.SmartphoneId == id && x.VotedById == userId);

            if (canVote)
            {
                this.Data.Smartphones.GetById(id).Votes.Add(new Vote
                {
                    SmartphoneId = id,
                    VotedById = userId
                });

                this.Data.SaveChanges();
            }

            var votes = this.Data.Smartphones.GetById(id).Votes.Count();

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
                    SmartphoneId = commentModel.SmartphoneId,
                });

                this.Data.SaveChanges();

                var viewModel = new CommentViewModel { AuthorUsername = username, Content = commentModel.Comment };
                return PartialView("_CommentPartial", viewModel);
            }

            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, ModelState.Values.First().ToString());
        }

        public ActionResult ListAll() 
        {
            if (this.HttpContext.Cache["ListAllSmartPhones"] == null)
            {
                var listOfSmartphones = this.Data.Smartphones.All()
                .OrderByDescending(x => x.Votes.Count())
                .Select(x => new SmartphoneViewModel
                {
                    Id = x.Id,
                    Manufacturer = x.Manufacturer.Name,
                    ImageUrl = x.ImageURL,
                    Model = x.Model,
                    Price = x.Price,
                    Votes = x.Votes.Count(),
                });
                this.HttpContext.Cache.Add("ListAllSmartPhones", listOfSmartphones.ToList(), null, DateTime.Now.AddHours(1), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Default, null);
            }

            return View(this.HttpContext.Cache["ListAllSmartPhones"]);
        }
    }
}