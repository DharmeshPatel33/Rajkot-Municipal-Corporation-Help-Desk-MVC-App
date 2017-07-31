using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace RMCHelpDesk.Models
{
    public class ComplainRegistrationModel
    {
        public int ID { get; set; }
        [Display(Name ="Your Name")]
        [Required]
        public string UserName { get; set; }
        [Display(Name ="Mobile No.")]
        [Required]

        public string MobileNO { get; set; }
        [Display(Name = "Your Address")]
        [Required]
        public string Address { get; set; }
        [Display(Name = "Aadhar Card No.")]
        [Required]
        public string Aadhar { get; set; }
        [Display(Name = "Discribe your problem here")]
        [Required]
        [DataType(DataType.MultilineText)]
        public string Problem { get; set; }

        public int DepartmentID { get; set; }
        public DepartmentModel Department { get; set; }

        public string  Status { get; set; }

        public DateTime Date { get; set; }
    }
}