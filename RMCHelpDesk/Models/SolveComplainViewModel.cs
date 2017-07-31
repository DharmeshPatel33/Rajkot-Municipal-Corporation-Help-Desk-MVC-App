using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMCHelpDesk.Models
{
    public class SolveComplainViewModel
    {
        public ComplainRegistrationModel Complain { get; set; }
        public DepartmentModel Department { get; set; }

        public Officer officer { get; set; }
        
    }
}