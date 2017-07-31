using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RMCHelpDesk.Models;

namespace RMCHelpDesk.Controllers
{
    public class ComplainsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Complains/Assign/5
        public ActionResult Assign(int? id)
        {
            ViewBag.ComplainRegistratationID = id;
            ComplainRegistrationModel c = new ComplainRegistrationModel();
            c = db.Complains.Find(id);
            ViewBag.Complaintext = c.Problem;
            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "Name",c.DepartmentID);
            ViewBag.OfficerID = new SelectList(db.Officers, "ID", "Name");

            return View();
        }
        // GET: Complains
        public ActionResult Index()
        {
            var complainDetails = db.ComplainDetails.Include(c => c.ComplainRegistratation).Include(c => c.Department).Include(c => c.Officer);
            return View(complainDetails.ToList());
        }

        // GET: Complains/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complain complain = db.ComplainDetails.Find(id);
            if (complain == null)
            {
                return HttpNotFound();
            }
            return View(complain);
        }

        // GET: Complains/Create
        public ActionResult Create()
        {
            ViewBag.ComplainRegistratationID = new SelectList(db.Complains, "ID", "UserName");
            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "Name");
            ViewBag.OfficerID = new SelectList(db.Officers, "ID", "Name");
            return View();
        }

        // POST: Complains/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Complaintext,ComplainRegistratationID,DepartmentID,OfficerID,Date")] Complain complain)
        {
            if (ModelState.IsValid)
            {
                complain.Date = DateTime.Now.Date;
                db.ComplainDetails.Add(complain);
                ComplainRegistrationModel c = new ComplainRegistrationModel();
                c = db.Complains.Find(complain.ComplainRegistratationID);
                c.Status = "Assigned";
                db.Entry(c).State = EntityState.Modified;
                db.SaveChanges();


                return RedirectToAction("Index");
            }

            ViewBag.ComplainRegistratationID = complain.ComplainRegistratationID;
            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "Name", complain.DepartmentID);
            ViewBag.OfficerID = new SelectList(db.Officers, "ID", "Name", complain.OfficerID);
            return View(complain);
        }

        // GET: Complains/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complain complain = db.ComplainDetails.Find(id);
            if (complain == null)
            {
                return HttpNotFound();
            }
            ViewBag.ComplainRegistratationID = new SelectList(db.Complains, "ID", "UserName", complain.ComplainRegistratationID);
            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "Name", complain.DepartmentID);
            ViewBag.OfficerID = new SelectList(db.Officers, "ID", "Name", complain.OfficerID);
            return View(complain);
        }

        // POST: Complains/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Complaintext,ComplainRegistratationID,DepartmentID,OfficerID,Date")] Complain complain)
        {
            if (ModelState.IsValid)
            {
                db.Entry(complain).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ComplainRegistratationID = new SelectList(db.Complains, "ID", "UserName", complain.ComplainRegistratationID);
            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "Name", complain.DepartmentID);
            ViewBag.OfficerID = new SelectList(db.Officers, "ID", "Name", complain.OfficerID);
            return View(complain);
        }

        // GET: Complains/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complain complain = db.ComplainDetails.Find(id);
            if (complain == null)
            {
                return HttpNotFound();
            }
            return View(complain);
        }

        // POST: Complains/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Complain complain = db.ComplainDetails.Find(id);
            db.ComplainDetails.Remove(complain);
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
