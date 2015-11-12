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
    public class CommentsAdministrationController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CommentsAdministration
        public ActionResult Index()
        {
            var comments = db.Comments.Include(c => c.Author).Include(c => c.Smartphone);
            return View(comments.ToList());
        }

        // GET: CommentsAdministration/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            var users = this.Data.ApplicationUsers.All();
            ViewBag.AuthorId = new SelectList(users, "Id", "Email", comment.AuthorId);
            ViewBag.SmartphoneId = new SelectList(db.Smartphones, "Id", "Model", comment.SmartphoneId);
            return View(comment);
        }

        // POST: CommentsAdministration/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AuthorId,SmartphoneId,Content")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var users = this.Data.ApplicationUsers.All();
            ViewBag.AuthorId = new SelectList(users, "Id", "Email", comment.AuthorId);
            ViewBag.SmartphoneId = new SelectList(db.Smartphones, "Id", "Model", comment.SmartphoneId);
            return View(comment);
        }

        // GET: CommentsAdministration/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: CommentsAdministration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
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
