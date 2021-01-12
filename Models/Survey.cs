using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SurveyPortal.Models
{
    public class Survey
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime StartDate { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime EndDate { get; set; }

        public virtual ICollection<SurveyQuestion> Questions { get; set; }

    }
}