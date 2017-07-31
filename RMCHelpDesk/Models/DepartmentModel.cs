using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RMCHelpDesk.Models
{
    public class DepartmentModel
    {
        public int ID { get; set; }

        [Display(Name="Department Name")]
        [Required]
        public string Name { get; set; }

        public string  Location { get; set; }

        [Display(Name="Name of Head of Department")]
        [Required]
        public string  HeadOfDepartment { get; set; }

        [Display(Name="Contact No. of HOD")]
        public string  ContactNo { get; set; }
    }
}