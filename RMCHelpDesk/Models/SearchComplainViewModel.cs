using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RMCHelpDesk.Models
{
    public class SearchComplainViewModel
    {
        public int Ticket_ID { get; set; }
        public string Problem { get; set; }

        public DepartmentModel Department { get; set; }

        public string Status { get; set; }

        public DateTime Date { get; set; }
    }
}