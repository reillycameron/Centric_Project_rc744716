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
using Microsoft.AspNet.Identity;
using static Centric_Project_rc744716.Models.Nominate;

namespace Centric_Project_rc744716.Controllers
{
    public class NominatesController : Controller
    {
        private CentricContext db = new CentricContext();

        // GET: Nominates
        [Authorize]
        public ActionResult Index()
        {
            var nominates = db.Nominates.Include(n => n.profile).OrderByDescending(a=>a.date);
            var nominatesList = nominates.ToList();
            ViewBag.nominates = nominatesList;
            
            var totalCount = nominatesList.Count();
            var excCount = nominatesList.Where(r => r.value == Nominate.valueRec.Excellence).Count();
            var intCount = nominatesList.Where(r => r.value == Nominate.valueRec.Integrity).Count();
            var steCount = nominatesList.Where(r => r.value == Nominate.valueRec.Stewardship).Count();
            var culCount = nominatesList.Where(r => r.value == Nominate.valueRec.Culture).Count();
            var pasCount = nominatesList.Where(r => r.value == Nominate.valueRec.Passion).Count();
            var innCount = nominatesList.Where(r => r.value == Nominate.valueRec.Innovate).Count();
            var balCount = nominatesList.Where(r => r.value == Nominate.valueRec.Balance).Count();
            ViewBag.total = totalCount;
            ViewBag.excellence = excCount;
            ViewBag.integrity = intCount;
            ViewBag.stewardship = steCount;
            ViewBag.culture = culCount;
            ViewBag.passion = pasCount;
            ViewBag.innovate = innCount;
            ViewBag.balance = balCount;

            return View(nominates.ToList());
        }
        [Authorize]
        public ActionResult PersonalNominations()
        {
            Guid newProfileID;
            Guid.TryParse(User.Identity.GetUserId(), out newProfileID);
            var nominates = db.Nominates.Where(n => n.profileID == newProfileID).OrderByDescending(a => a.date);
            return View(nominates.ToList());
        }

        [Authorize]
        public ActionResult GivenNominations()
        {
            Guid newProfileID;
            Guid.TryParse(User.Identity.GetUserId(), out newProfileID);
            var nominates = db.Nominates.Where(n => n.nominator == newProfileID).OrderByDescending(a => a.date);
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
        [Authorize]
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
                Guid newProfileID;
                Guid.TryParse(User.Identity.GetUserId(), out newProfileID);
                nominate.nominator = newProfileID;
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
