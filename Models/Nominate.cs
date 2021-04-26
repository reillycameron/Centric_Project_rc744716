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
        public Guid profileID { get; set; }
        [ForeignKey("profileID")]
        public virtual Profile profile { get; set; }

        public Guid nominator { get; set; }
        [ForeignKey("nominator")]
        public virtual Profile Giver { get; set; }

        [Display(Name = "Today's Date")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage  = "Please enter today's date like 1/1/21.")]
        public DateTime date { get; set; }

        [Required(ErrorMessage = "You must select a Centric Value the employee has shown.")]

        [Display(Name = "Value Recognized")]
        
        public valueRec value { get; set; }

        [Display(Name = "Brief Description of How Employee Reflected This Value")]
        [Required(ErrorMessage = "You must add details on how the employee has shown the value.")]
        [StringLength(250, ErrorMessage = "Please include details in 250 characters or less.")]

        public string valueComment { get; set; }

        public enum valueRec
        {
            [Display(Name = "Commit to Delivery Excellence")]
            Excellence = 1,
            [Display(Name = "Embrace Integrity and Openness")]
            Integrity = 2,
            [Display(Name = "Practice Responsible Stewardship")]
            Stewardship = 3,
            [Display(Name = "Invest in an Exceptional Culture")]
            Culture = 4,
            [Display(Name = "Ignite Passion for the Greater Good")]
            Passion = 5,
            [Display(Name = "Strive to Innovate")]
            Innovate = 6,
            [Display(Name = "Live a Balanced Life")]
            Balance = 7

        }


    }
}