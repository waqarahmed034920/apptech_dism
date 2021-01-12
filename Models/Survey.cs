using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SurveyPortal.Models
{
    public class Survey
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Survey name is required")]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "Start date is required")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        
        [Required(ErrorMessage = "End date is required")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Back Button")]
        public bool BackButton { get; set; }
        public bool Reviewable { get; set; }
        [Display(Name = "Internal Survey")]
        public bool InternalOnly { get; set; }
        public string SurveyFor { get; set; }


    }
}