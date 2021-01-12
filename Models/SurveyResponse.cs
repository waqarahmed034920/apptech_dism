using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurveyPortal.Models
{
    public class SurveyResponse
    {
        public int Id { get; set; }

        public DateTime ResponseDate { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        public int SurveyId { get; set; }

        [ForeignKey("SurveyId")]
        public Survey Survey { get; set; }

    }
}