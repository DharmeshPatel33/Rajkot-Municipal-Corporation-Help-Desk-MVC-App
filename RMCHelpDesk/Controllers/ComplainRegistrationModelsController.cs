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
    [Authorize]
    public class ComplainRegistrationModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        int ticket_ID = 0;
        // GET: ComplainRegistrationModels
        public ActionResult Index()
        {
            var complains = db.Complains.Include(c => c.Department);
            return View(complains.ToList());
        }

        public ActionResult Dashboard()
        {
            DashboardModel dashboard = new DashboardModel();
            dashboard.PendingComplains = db.Complains.Where(c => c.Status == "Panding").Count();
            dashboard.AssignedComplains = db.Complains.Where(c => c.Status == "Assigned").Count();
            dashboard.SolvedComplains = db.Complains.Where(c => c.Status == "Solved").Count();
            return View(dashboard);
        }
        [AllowAnonymous]
        public ActionResult SearchComplain(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RMCHelpDesk.Models.SearchComplainViewModel searchcomplain = new SearchComplainViewModel();
            RMCHelpDesk.Models.ComplainRegistrationModel complain = db.Complains.Find(id);
                        
            if(complain==null)
            {
                return HttpNotFound();
            }
            searchcomplain.Ticket_ID = complain.ID;
            searchcomplain.Problem = complain.Problem;
            searchcomplain.Department.Name = complain.Department.Name;
            searchcomplain.Status = complain.Status;
            searchcomplain.Date = complain.Date;
            return View(searchcomplain); 
        }
        [AllowAnonymous]
        public ActionResult TicketView(int t_id)
        {
            TicketViewModel tvm = new TicketViewModel();
            tvm.Ticket_No = t_id;
            ComplainRegistrationModel complainRegistrationModel=db.Complains.Find(t_id);
            tvm.UserName = complainRegistrationModel.UserName;
            DepartmentModel dpt = db.Departments.Find(complainRegistrationModel.DepartmentID);
            tvm.DepartmentName = dpt.Name;
            tvm.Location = dpt.Location;
            tvm.HODName = dpt.HeadOfDepartment;
            tvm.Contact_NO = dpt.ContactNo;
            return View(tvm);
        }

        // GET: ComplainRegistrationModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComplainRegistrationModel complainRegistrationModel = db.Complains.Find(id);
            if (complainRegistrationModel == null)
            {
                return HttpNotFound();
            }
            return View(complainRegistrationModel);
        }


        // GET: ComplainRegistrationModels/Create
        [AllowAnonymous]
        public ActionResult Create()
        {
            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "Name");
            return View();
        }

        // POST: ComplainRegistrationModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserName,MobileNO,Address,Aadhar,Problem,DepartmentID")] ComplainRegistrationModel complainRegistrationModel)
        {
            if (ModelState.IsValid)
            {
                complainRegistrationModel.Status = "Panding";
                complainRegistrationModel.Date = DateTime.Now.Date;
              //  ticket_ID = complainRegistrationModel.ID;
                db.Complains.Add(complainRegistrationModel);
                db.SaveChanges();
             //   complainRegistrationModel = db.Complains.LastOrDefault();
                ticket_ID = complainRegistrationModel.ID;
                return RedirectToAction("TicketView",new { t_id = ticket_ID});
               // return RedirectToAction("Index");
            }

            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "Name", complainRegistrationModel.DepartmentID);
            return View(complainRegistrationModel);
        }

        // GET: ComplainRegistrationModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComplainRegistrationModel complainRegistrationModel = db.Complains.Find(id);
            if (complainRegistrationModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "Name", complainRegistrationModel.DepartmentID);
            return View(complainRegistrationModel);
        }

        // POST: ComplainRegistrationModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserName,MobileNO,Address,Aadhar,Problem,DepartmentID,Status")] ComplainRegistrationModel complainRegistrationModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(complainRegistrationModel).State = EntityState.Modified;
                db.SaveChanges();
               return RedirectToAction("Index");
                
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "Name", complainRegistrationModel.DepartmentID);
            return View(complainRegistrationModel);
        }

        // GET: ComplainRegistrationModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComplainRegistrationModel complainRegistrationModel = db.Complains.Find(id);
            if (complainRegistrationModel == null)
            {
                return HttpNotFound();
            }
            return View(complainRegistrationModel);
        }

        // POST: ComplainRegistrationModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ComplainRegistrationModel complainRegistrationModel = db.Complains.Find(id);
            db.Complains.Remove(complainRegistrationModel);
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
