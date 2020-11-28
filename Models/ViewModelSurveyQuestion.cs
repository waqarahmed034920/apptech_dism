using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurveyPortal.Models
{
    public class ViewModelSurveyQuestion
    {
        public Survey Survey { get; set; }
        public List<SurveyQuestion> Questions { get; set; }

    }
}