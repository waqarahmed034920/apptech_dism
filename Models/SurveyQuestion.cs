using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SurveyPortal.Models
{
    public class SurveyQuestion
    {
        public int Id { get; set; }
        public int SurveyId { get; set; }
        public string Question { get; set; }

        [Display(Name ="Option Type Id")]
        public int OptionTypeId { get; set; }

        [Display(Name = "No Of Options")] 
        public int NoOfOptions { get; set; }
        public string Options { get; set; }
    }
}