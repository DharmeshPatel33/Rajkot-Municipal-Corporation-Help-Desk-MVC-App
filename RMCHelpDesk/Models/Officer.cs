using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RMCHelpDesk.Models
{
    public class Officer
    {
        public int ID { get; set; }

        [Display(Name="Officer Full Name.")]
        [Required]
        public string Name { get; set; }

        public int? DepartmentID { get; set; }
        public DepartmentModel Department { get; set; }

    }
}