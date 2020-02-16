using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SavingLives_WebApp.Models;

namespace SavingLives_WebApp.Controllers
{
    public class NewRequirementController : Controller
    {
        private SavingLivesModel db = new SavingLivesModel();

        // GET: NewRequirement
        public ActionResult Index()
        {
            var newRequirements = db.NewRequirements.Include(n => n.BloodGroupDetail).Include(n => n.ReceiverDetail);
            return View(newRequirements.ToList());
        }

        // GET: NewRequirement/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewRequirement newRequirement = db.NewRequirements.Find(id);
            if (newRequirement == null)
            {
                return HttpNotFound();
            }
            return View(newRequirement);
        }

        // GET: NewRequirement/Create
        public ActionResult Create()
        {
            ViewBag.BloodGroupDetialsID = new SelectList(db.BloodGroupDetails, "BloodGroupDetailsID", "BloodGroupName");
            ViewBag.ReceiverID = new SelectList(db.ReceiverDetails, "ReceiverID", "UserID");
            return View();
        }

        // POST: NewRequirement/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NewRequirementID,ReceiverID,BloodGroupDetialsID,ExpectedDate,NumOfUnitsReq,CreatedBy,CreatedDate,LastModifiedBy,LastModifiedDate")] NewRequirement newRequirement)
        {
            if (ModelState.IsValid)
            {
                db.NewRequirements.Add(newRequirement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BloodGroupDetialsID = new SelectList(db.BloodGroupDetails, "BloodGroupDetailsID", "BloodGroupName", newRequirement.BloodGroupDetialsID);
            ViewBag.ReceiverID = new SelectList(db.ReceiverDetails, "ReceiverID", "UserID", newRequirement.ReceiverID);
            return View(newRequirement);
        }

        // GET: NewRequirement/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewRequirement newRequirement = db.NewRequirements.Find(id);
            if (newRequirement == null)
            {
                return HttpNotFound();
            }
            ViewBag.BloodGroupDetialsID = new SelectList(db.BloodGroupDetails, "BloodGroupDetailsID", "BloodGroupName", newRequirement.BloodGroupDetialsID);
            ViewBag.ReceiverID = new SelectList(db.ReceiverDetails, "ReceiverID", "UserID", newRequirement.ReceiverID);
            return View(newRequirement);
        }

        // POST: NewRequirement/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NewRequirementID,ReceiverID,BloodGroupDetialsID,ExpectedDate,NumOfUnitsReq,CreatedBy,CreatedDate,LastModifiedBy,LastModifiedDate")] NewRequirement newRequirement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newRequirement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BloodGroupDetialsID = new SelectList(db.BloodGroupDetails, "BloodGroupDetailsID", "BloodGroupName", newRequirement.BloodGroupDetialsID);
            ViewBag.ReceiverID = new SelectList(db.ReceiverDetails, "ReceiverID", "UserID", newRequirement.ReceiverID);
            return View(newRequirement);
        }

        // GET: NewRequirement/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewRequirement newRequirement = db.NewRequirements.Find(id);
            if (newRequirement == null)
            {
                return HttpNotFound();
            }
            return View(newRequirement);
        }

        // POST: NewRequirement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NewRequirement newRequirement = db.NewRequirements.Find(id);
            db.NewRequirements.Remove(newRequirement);
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
