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
    public class BloodGroupDetailController : Controller
    {
        private SavingLivesModel db = new SavingLivesModel();

        // GET: BloodGroupDetail
        public ActionResult Index()
        {
            return View(db.BloodGroupDetails.ToList());
        }

        // GET: BloodGroupDetail/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodGroupDetail bloodGroupDetail = db.BloodGroupDetails.Find(id);
            if (bloodGroupDetail == null)
            {
                return HttpNotFound();
            }
            return View(bloodGroupDetail);
        }

        // GET: BloodGroupDetail/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BloodGroupDetail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BloodGroupDetailsID,BloodGroupName,CreatedBy,CreatedDate,LastModifiedBy,LastModifiedDate")] BloodGroupDetail bloodGroupDetail)
        {
            if (ModelState.IsValid)
            {
                db.BloodGroupDetails.Add(bloodGroupDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bloodGroupDetail);
        }

        // GET: BloodGroupDetail/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodGroupDetail bloodGroupDetail = db.BloodGroupDetails.Find(id);
            if (bloodGroupDetail == null)
            {
                return HttpNotFound();
            }
            return View(bloodGroupDetail);
        }

        // POST: BloodGroupDetail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BloodGroupDetailsID,BloodGroupName,CreatedBy,CreatedDate,LastModifiedBy,LastModifiedDate")] BloodGroupDetail bloodGroupDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bloodGroupDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bloodGroupDetail);
        }

        // GET: BloodGroupDetail/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodGroupDetail bloodGroupDetail = db.BloodGroupDetails.Find(id);
            if (bloodGroupDetail == null)
            {
                return HttpNotFound();
            }
            return View(bloodGroupDetail);
        }

        // POST: BloodGroupDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BloodGroupDetail bloodGroupDetail = db.BloodGroupDetails.Find(id);
            db.BloodGroupDetails.Remove(bloodGroupDetail);
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
