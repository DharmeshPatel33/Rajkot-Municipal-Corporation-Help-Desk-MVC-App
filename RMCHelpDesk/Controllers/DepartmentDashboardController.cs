using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RMCHelpDesk.Models;
namespace RMCHelpDesk.Controllers
{
    public class DepartmentDashboardController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: DepartmentDashboard
        public ActionResult Index()
        {

            var Department = db.Departments.ToList();
            List<DepartmentWiseComplainViewModel> dptviewmodel = new List<DepartmentWiseComplainViewModel>();
            DepartmentWiseComplainViewModel dpttemp = new DepartmentWiseComplainViewModel();
            foreach (var Dpt in Department)
            {
                
                dptviewmodel.Add(new DepartmentWiseComplainViewModel {
                    Department=Dpt,
                    Pending= db.Complains.Where(c => c.DepartmentID == Dpt.ID).Where(c => c.Status == "Pending").Count(),
                    Solved= db.Complains.Where(c => c.DepartmentID == Dpt.ID).Where(c => c.Status == "Solved").Count(),
                    Assigned= db.Complains.Where(c => c.DepartmentID == Dpt.ID).Where(c => c.Status == "Assigned").Count()
                });
            }
            return View(dptviewmodel.ToList());
        }
        public ActionResult Details(string ctype,int?dtype)
        {
            var complains = db.Complains.Where(c => c.DepartmentID == dtype).Where(c => c.Status == ctype).ToList();
            ViewBag.DepartmentName = db.Departments.Find(dtype).Name;
            return View(complains);
        }
    }
}