using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMCHelpDesk.Models
{
    public class DashboardModel
    {
        public int PendingComplains { get; set; }

        public int AssignedComplains { get; set; }

        public int SolvedComplains { get; set; }
    }
}