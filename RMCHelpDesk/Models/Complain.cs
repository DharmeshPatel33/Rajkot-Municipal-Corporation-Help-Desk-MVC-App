using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RMCHelpDesk.Models
{
    public class Complain
    {
        public int ID { get; set; }

        [Display(Name ="Complain Registration")]
        public string Complaintext { get; set; }

        public int ComplainRegistratationID { get; set; }

        public ComplainRegistrationModel ComplainRegistratation { get; set; }

        
        [Display(Name = "Select Department")]
        public int? DepartmentID { get; set; }
        [ForeignKey("DepartmentID")]
        public DepartmentModel Department { get; set; }

        [Display(Name = "Select Officer")]
        public int OfficerID { get; set; }

        public Officer Officer { get; set; }
        [Display(Name ="Complain Assigned Date")]    
        public DateTime Date { get; set; }
    }
}