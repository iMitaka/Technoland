using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Net.Http;
using Technoland.Web.Models;

namespace Technoland.Web.Controllers
{
    public class SmartphoneController : BaseController
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
                    Audio35Jack = x.Audio35Jack,
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
                    BatteryLiveWhenListeningMusic = x.BatteryLiveWhenListeningMusic,
                    BattryType = x.BattryType,
                    BluetoothInfo = x.BluetoothInfo,
                    GPU = x.GPU,
                    externalMomory = x.externalMomory,
                    internalMemory = x.internalMemory,
                    Java = x.Java,
                    Frequency = x.Frequency,
                    HoursOfTalk = x.HoursOfTalk,
                    MessagesInfo = x.MessagesInfo,
                    Multitouch = x.Multitouch,
                    Radio = x.Radio,
                    RAM = x.RAM,
                    RAMMemoryType = x.RAMMemoryType,
                    Resolution = x.Resolution,
                    VideoResolutionP = x.VideoResolutionP,
                    WLANInfo = x.WLANInfo,
                }).FirstOrDefault();

            return View(viewModel);
        }
    }
}