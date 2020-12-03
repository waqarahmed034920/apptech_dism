using System;
using System.Collections.Generic;
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
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string SurveyName { get; set; }
        public string SurveyDescription { get; set; }

    }
}