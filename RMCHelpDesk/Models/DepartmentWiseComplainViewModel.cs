using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMCHelpDesk.Models
{
    public class DepartmentWiseComplainViewModel
    {
        public DepartmentModel Department { get; set; }

        public int Pending { get; set; }
        public int Assigned { get; set; }
        public int Solved { get; set; }
    }
}