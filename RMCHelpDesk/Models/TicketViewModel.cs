using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace RMCHelpDesk.Models
{
    public class TicketViewModel
    {
        [Display(Name = "Your Ticket ID")]
        public int Ticket_No { get; set; }
        [Display(Name ="Your Name")]
        public string UserName { get; set; }
        [Display(Name = "Name Of Department")]
        public string  DepartmentName { get; set; }

        [Display(Name = "Location of Department")]
        public string Location { get; set; }
        [Display(Name = "Head of Department Name")]
        public string HODName { get; set; }
        [Display(Name = "Office Contact No")]
        public string Contact_NO { get; set; }
    }
}