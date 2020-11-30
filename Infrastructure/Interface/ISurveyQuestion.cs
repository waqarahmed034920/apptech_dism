using SurveyPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyPortal.Infrastructure.Interface
{
    public interface ISurveyQuestion : IRepository<SurveyQuestion>
    {
        List<SurveyQuestion> GetQuestionsBySurveyId(int SurveyId);

    }
}
