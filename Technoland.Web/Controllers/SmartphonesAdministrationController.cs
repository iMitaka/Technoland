using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Technoland.Data;
using Technoland.Models;

namespace Technoland.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SmartphonesAdministrationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SmartphonesAdministration
        public ActionResult Index()
        {
            var smartphones = db.Smartphones.Include(s => s.Manufacturer);
            return View(smartphones.ToList());
        }

        // GET: SmartphonesAdministration/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Smartphone smartphone = db.Smartphones.Find(id);
            if (smartphone == null)
            {
                return HttpNotFound();
            }
            return View(smartphone);
        }

        // GET: SmartphonesAdministration/Create
        public ActionResult Create()
        {
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers.Where(m => m.HasSmartphones == true), "Id", "Name");
            return View();
        }

        // POST: SmartphonesAdministration/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ManufacturerId,Model,ImageURL,connection2G,connection3G,connection4G,GPRS,EDGE,HSDPA,HSUPA,Weight,SIMType,ScreenType,ScreenColors,ScreenSize,Resolution,Multitouch,ScreenProtection,internalMemory,externalMomory,RAM,RAMMemoryType,CameraPixels,CameraResolution,SecondaryCameraPixels,VideoFPS,VideoResolutionP,additionalCameraFunctions,USB,StereoSound,OS,Chipset,Frequency,Cores,GPU,GPSInformation,Senzors,MessagesInfo,DeffoultBrowser,BattryType,BatteryCappacity,HoursOfTalk,HoursListenOfMusic,WLANInfo,BluetoothInfo,Price")] Smartphone smartphone)
        {
            if (ModelState.IsValid)
            {
                db.Smartphones.Add(smartphone);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "Id", "Name", smartphone.ManufacturerId);
            return View(smartphone);
        }

        // GET: SmartphonesAdministration/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Smartphone smartphone = db.Smartphones.Find(id);
            if (smartphone == null)
            {
                return HttpNotFound();
            }
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "Id", "Name", smartphone.ManufacturerId);
            return View(smartphone);
        }

        // POST: SmartphonesAdministration/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ManufacturerId,Model,ImageURL,connection2G,connection3G,connection4G,GPRS,EDGE,HSDPA,HSUPA,Weight,SIMType,ScreenType,ScreenColors,ScreenSize,Resolution,Multitouch,ScreenProtection,internalMemory,externalMomory,RAM,RAMMemoryType,CameraPixels,CameraResolution,SecondaryCameraPixels,VideoFPS,VideoResolutionP,additionalCameraFunctions,USB,StereoSound,OS,Chipset,Frequency,Cores,GPU,GPSInformation,Senzors,MessagesInfo,DeffoultBrowser,BattryType,BatteryCappacity,HoursOfTalk,HoursListenOfMusic,WLANInfo,BluetoothInfo,Price")] Smartphone smartphone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(smartphone).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "Id", "Name", smartphone.ManufacturerId);
            return View(smartphone);
        }

        // GET: SmartphonesAdministration/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Smartphone smartphone = db.Smartphones.Find(id);
            if (smartphone == null)
            {
                return HttpNotFound();
            }
            return View(smartphone);
        }

        // POST: SmartphonesAdministration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Smartphone smartphone = db.Smartphones.Find(id);
            foreach (var vote in smartphone.Votes.ToList())
            {
                db.Votes.Remove(vote);
            }
            foreach (var comment in smartphone.Comments.ToList())
            {
                db.Comments.Remove(comment);
            }
            db.Smartphones.Remove(smartphone);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
