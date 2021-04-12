using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Centric_Project_rc744716.Models
{
    public class Profile
    {
        public Guid profileID { get; set; }
        [Display(Name = "First Name")]
        [Required]
        [StringLength(30, ErrorMessage = "Employee First Name must be 30 characters or less.")]
        [RegularExpression("^([a-zA-Z']+)$", ErrorMessage = "Employee first name may only include letters and an optional '")]
        public string firstName { get; set; }
        [Display(Name ="Last Name")]
        [Required]
        [StringLength(30, ErrorMessage = "Employee Last Name must be 30 characters or less.")]
        [RegularExpression("^([a-zA-Z']+)$", ErrorMessage = "Employee last name may only include letters and an optional '")]
        public string lastName { get; set; }
        [Display(Name ="Employee Name")]
        [Required]
        public string fullName
        {
            get
            {
                return lastName + ", " + firstName;
            }
    }
        [Display(Name ="Business Unit")]
        [Required]
        [StringLength(30, ErrorMessage = "Office must be 30 characters or less.")]
        public string office { get; set; }
        [Display(Name ="Position")]
        [Required]
        [StringLength(30, ErrorMessage = "Position must be 30 characters or less.")]
        public string position { get; set; }
        [ForeignKey("profileID")]
        public ICollection<Nominate> nominate { get; set; }
        [ForeignKey("nominator")]
        public ICollection<Nominate> nominator { get; set; }

    }
}