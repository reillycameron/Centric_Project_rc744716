using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Centric_Project_rc744716.Models
{
    public class Nominate
    {
        public int nominateID { get; set; }

        [Required(ErrorMessage = "You must select an employee to nominate.")]
        [Display(Name = "Employee Name")]
        public int profileID { get; set; }
        public virtual Profile profile { get; set; }

        [Display(Name = "Today's Date")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage  = "Please enter today's date like 1/1/21.")]
        public DateTime date { get; set; }

        [Required(ErrorMessage = "You must select a Centric Value the employee has shown.")]

        [Display(Name = "Value Recognized")]
        
        public IEnumerable<SelectListItem> valueRec { get; set; }

        [Display(Name = "Brief Description of How Employee Reflected this Value")]
        [Required(ErrorMessage = "You must add details on how the employee has shown the value.")]
        [StringLength(250, ErrorMessage = "Please include details in 250 characters or less.")]

        public string valueComment { get; set; }

    }
}