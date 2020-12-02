using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurveyPortal.Models
{
    public class Competition
    {
        public int Id { get; set; }
        public string Introduction { get; set; }
        public string Details { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Role { get; set; }
    }
}