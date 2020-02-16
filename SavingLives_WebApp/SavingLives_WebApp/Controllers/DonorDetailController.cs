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
    public class DonorDetailController : Controller
    {
        private SavingLivesModel db = new SavingLivesModel();

        [Authorize]
        // GET: DonorDetail
        public ActionResult Index()
        {
            var donorDetails = db.DonorDetails.Include(d => d.AspNetUser);
            return View(donorDetails.ToList());
        }

        // GET: DonorDetail/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonorDetail donorDetail = db.DonorDetails.Find(id);
            if (donorDetail == null)
            {
                return HttpNotFound();
            }
            return View(donorDetail);
        }

        [Authorize(Roles ="Admin")]
        // GET: DonorDetail/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: DonorDetail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DonorID,UserID,FirstName,LastName,EmailID,PhoneNum,Address,City,State,Country,BloodGroup,Verified,ProofOfBloodGroup,DonorStatus,CreatedBy,CreatedDate,LastModifiedBy,lastModifiedDate")] DonorDetail donorDetail)
        {
            if (ModelState.IsValid)
            {
                db.DonorDetails.Add(donorDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.AspNetUsers, "Id", "Email", donorDetail.UserID);
            return View(donorDetail);
        }

        // GET: DonorDetail/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonorDetail donorDetail = db.DonorDetails.Find(id);
            if (donorDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.AspNetUsers, "Id", "Email", donorDetail.UserID);
            return View(donorDetail);
        }

        // POST: DonorDetail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DonorID,UserID,FirstName,LastName,EmailID,PhoneNum,Address,City,State,Country,BloodGroup,Verified,ProofOfBloodGroup,DonorStatus,CreatedBy,CreatedDate,LastModifiedBy,lastModifiedDate")] DonorDetail donorDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donorDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.AspNetUsers, "Id", "Email", donorDetail.UserID);
            return View(donorDetail);
        }

        // GET: DonorDetail/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonorDetail donorDetail = db.DonorDetails.Find(id);
            if (donorDetail == null)
            {
                return HttpNotFound();
            }
            return View(donorDetail);
        }

        // POST: DonorDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DonorDetail donorDetail = db.DonorDetails.Find(id);
            db.DonorDetails.Remove(donorDetail);
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
