using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurveyPortal.Models
{
    public class SurveyQuestion
    {
        public int Id { get; set; }
        public string Question { get; set; }

        public int SurveyId { get; set; }

        [ForeignKey("SurveyId")]
        public Survey Survey { get; set; }

        public List<Option> Options { get; set; }

    }
}