using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using RMCHelpDesk.Models;
namespace RMCHelpDesk.Controllers
{
    public class SolveComplainController : Controller
    {
       private ApplicationDbContext db = new ApplicationDbContext();
        // GET: SolveComplain
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Complains");
        }

        public ActionResult Solve(int? id)
        {
            Complain complain = db.ComplainDetails.Find(id);
            complain.ComplainRegistratation = db.Complains.Find(complain.ComplainRegistratationID);
            complain.Department = db.Departments.Find(complain.DepartmentID);
            complain.Officer = db.Officers.Find(complain.OfficerID);
            return View(complain);
        }

        [HttpPost]
        public ActionResult Solve(Complain complain)
        {
            ComplainRegistrationModel cm = new ComplainRegistrationModel();
            Complain temp = new Complain();
            temp = db.ComplainDetails.Find(complain.ID);


            cm = db.Complains.Find(temp.ComplainRegistratationID);
            cm.Status = "Solved";
            db.Entry(cm).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index", "ComplainRegistrationModels");
        }
    }
}