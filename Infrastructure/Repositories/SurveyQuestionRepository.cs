using SurveyPortal.Infrastructure.Interface;
using SurveyPortal.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SurveyPortal.Infrastructure.Repositories
{
    public class SurveyQuestionRepository : ISurveyQuestion
    {
        private ApplicationDbContext context;
        public SurveyQuestionRepository()
        {
            this.context = new ApplicationDbContext();
        }

        public bool Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public List<SurveyQuestion> GetAll()
        {
            throw new NotImplementedException();
        }

        public SurveyQuestion GetById(int Id)
        {
            var SQ = context.SurveyQuestions
                     .Include("Options")
                     .Where(Q => Q.Id == Id);

            return SQ.First();
        }

        public List<SurveyQuestion> GetQuestionsBySurveyId(int SurveyId)
        {
            return context.SurveyQuestions.Where(q => q.SurveyId == SurveyId).ToList();
        }

        public bool Insert(SurveyQuestion objT)
        {
            throw new NotImplementedException();
        }

        public bool Update(SurveyQuestion objT)
        {
            throw new NotImplementedException();
        }
    }
}