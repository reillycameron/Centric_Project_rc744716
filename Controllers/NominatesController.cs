using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Centric_Project_rc744716.DAL;
using Centric_Project_rc744716.Models;

namespace Centric_Project_rc744716.Controllers
{
    public class NominatesController : Controller
    {
        private CentricContext db = new CentricContext();

        // GET: Nominates
        public ActionResult Index()
        {
            var nominates = db.Nominates.Include(n => n.profile);
            return View(nominates.ToList());
        }

        // GET: Nominates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nominate nominate = db.Nominates.Find(id);
            if (nominate == null)
            {
                return HttpNotFound();
            }
            return View(nominate);
        }

        // GET: Nominates/Create
        public ActionResult Create()
        {
            ViewBag.profileID = new SelectList(db.profile, "profileID", "fullName");
            return View();
        }

        // POST: Nominates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nominateID,profileID,date,value,valueComment")] Nominate nominate)
        {
            if (ModelState.IsValid)
            {
                db.Nominates.Add(nominate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.profileID = new SelectList(db.profile, "profileID", "fullName", nominate.profileID);
            return View(nominate);
        }

        // GET: Nominates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nominate nominate = db.Nominates.Find(id);
            if (nominate == null)
            {
                return HttpNotFound();
            }
            ViewBag.profileID = new SelectList(db.profile, "profileID", "fullName", nominate.profileID);
            return View(nominate);
        }

        // POST: Nominates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "nominateID,profileID,date,value,valueComment")] Nominate nominate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nominate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.profileID = new SelectList(db.profile, "profileID", "fullName", nominate.profileID);
            return View(nominate);
        }

        // GET: Nominates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nominate nominate = db.Nominates.Find(id);
            if (nominate == null)
            {
                return HttpNotFound();
            }
            return View(nominate);
        }

        // POST: Nominates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nominate nominate = db.Nominates.Find(id);
            db.Nominates.Remove(nominate);
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
