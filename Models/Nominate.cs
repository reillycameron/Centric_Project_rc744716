using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Centric_Project_rc744716.Models
{
    public class Nominate
    {
        public int nominateID { get; set; }

        [Required(Errormessage = "You must select an employee to nominate.")]

        public int employeeID { get; set; }
        public virtual Profile profile { get; set; }

        public DateTime date { get; set; }

        [Required(Errormessage = "You must select a Centric Value the employee has shown.")]

        public string valueRec { get; set; }

        [Required(Errormessage = "You must add a detail on how the employee has shown the value.")]
        [StringLength(250, ErrorMessage = "Please include details in 250 characters or less.")]

        public string valueComment { get; set; }

        public ICollection<Profile> profile { get; set; }

    }
}