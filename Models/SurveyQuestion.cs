using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurveyPortal.Models
{
    public class SurveyQuestion
    {
        public int Id { get; set; }
        public int SurveyId { get; set; }
        public string Question { get; set; }
        public int OptionTypeId { get; set; }
        public int NoOfOptions { get; set; }

    }
}