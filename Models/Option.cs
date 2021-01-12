using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurveyPortal.Models
{
    public class Option
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public OptionType Type { get; set; }

        public int QuestionId { get; set; }

        [ForeignKey("QuestionId")]
        public SurveyQuestion Question { get; set; }
    }

    public enum OptionType
    {
        radio, 
        checkbox,
        text
    }
}