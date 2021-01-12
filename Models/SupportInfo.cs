using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurveyPortal.Models
{
    public class SupportInfo
    {
        public int Id { get; set; }
        public string Contact { get; set; }
        public string ShortDesc { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string WhatsApp { get; set; }
        public string SkypeId { get; set; }
        public string WebAddress { get; set; }

    }
}