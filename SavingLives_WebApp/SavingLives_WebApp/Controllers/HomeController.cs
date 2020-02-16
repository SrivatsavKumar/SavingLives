using SavingLives_WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SavingLives_WebApp.Controllers
{
    public class HomeController : Controller
    {
        SavingLivesModel _db = new SavingLivesModel();
        public ActionResult Index(string searchTerm = null)
        {
            var model = _db.DonorDetails
                .OrderByDescending(r => r.LastName)
                .Where(r => searchTerm == null || r.City.StartsWith(searchTerm))
                .Take(10)
                .Select(r => new DonorDetailListViewModel
                {
                    BloodGroup = r.BloodGroup,
                    City = r.City,
                    State = r.State,
                });
            //var model = from a in _db.DonorDetails
            //            where a.DonorStatus == "Active"
            //            select a;
            //var model = _db.DonorDetails.ToList();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Bring your kind heart to the below address..";

            return View();
        }
    }
}