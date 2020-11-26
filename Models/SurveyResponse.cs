using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurveyPortal.Models
{
    public class SurveyResponse
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime ResponseDate { get; set; }
        public string Response { get; set; }
    }
}