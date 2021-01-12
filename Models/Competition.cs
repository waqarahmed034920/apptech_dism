using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SurveyPortal.Models
{
    public class Competition
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int SurveyId { get; set; }
        public string Introduction { get; set; }
        public string Details { get; set; }
        
        [Required(ErrorMessage = "Start date is required")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End date is required")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        public string SurveyName { get; set; }
        public string SurveyDescription { get; set; }

    }
}