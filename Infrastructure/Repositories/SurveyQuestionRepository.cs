using SurveyPortal.Infrastructure.Interface;
using SurveyPortal.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SurveyPortal.Infrastructure.Repositories
{
    public class SurveyQuestionRepository : ISurveyQuestion
    {
        private ApplicationDbContext DB;

        public SurveyQuestionRepository()
        {
            DB = ApplicationDbContext.Create();
        }

        public bool Delete(int Id)
        {
            var sq = DB.surveyQuestions
                .Where(s => s.Id == Id)
                .FirstOrDefault();
            DB.surveyQuestions.Remove(sq);
            DB.SaveChanges();
            return true;
        }

        public List<SurveyQuestion> GetAll()
        {
            var query = from sq in DB.surveyQuestions
                        join su in DB.Surveys on sq.SurveyId equals su.Id
                        select new { sq, su };

            List<SurveyQuestion> lstSQ = new List<SurveyQuestion>();
            foreach (var obj in query.ToList())
            {
                SurveyQuestion objsur = new SurveyQuestion();
                objsur.Id = obj.sq.Id;
                objsur.SurveyId = obj.sq.SurveyId;
                objsur.Question = obj.sq.Question;
                objsur.OptionTypeId = obj.sq.OptionTypeId;
                objsur.NoOfOptions = obj.sq.NoOfOptions;
                objsur.Options = obj.sq.Options;
                objsur.OptionTypeName = obj.sq.OptionTypeName;
                
            }
            return lstSQ;
        }

        public SurveyQuestion GetById(int Id)
        {
            var query1 = from su in DB.surveyQuestions
                         where (su.Id == Id)
                         select su;
            return query1.FirstOrDefault();
        }

        public List<SurveyQuestion> GetQuestionsBySurveyId(int SurveyId)
        {
            try
            {

                var query = from sq in DB.surveyQuestions
                              join op in DB.OptionTypes on sq.OptionTypeId equals op.Id
                              where sq.SurveyId == SurveyId
                              select new { sq, op };


                List<SurveyQuestion> lstSurveyQuestions = new List<SurveyQuestion>();

                foreach(var data in query.ToList())
                {
                    SurveyQuestion objSurveyQuestion = new SurveyQuestion();
                    objSurveyQuestion.Id = data.sq.Id;
                    objSurveyQuestion.SurveyId = data.sq.SurveyId;
                    objSurveyQuestion.Question = data.sq.Question;
                    objSurveyQuestion.OptionTypeName = data.op.Name;
                    objSurveyQuestion.OptionTypeId = data.op.Id;
                    objSurveyQuestion.NoOfOptions = data.sq.NoOfOptions;
                    objSurveyQuestion.Options = data.sq.Options;
                    lstSurveyQuestions.Add(objSurveyQuestion);
                }
                return lstSurveyQuestions;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert(SurveyQuestion objT)
        {
            DB.surveyQuestions.Add(objT);
            DB.SaveChanges();
            return true;
        }

        public bool Update(SurveyQuestion objT)
        {
            var existing = DB.surveyQuestions.Where(s => s.Id == objT.Id).First();
            DB.Entry(existing).CurrentValues.SetValues(objT);
            DB.SaveChanges();
            return true;
        }
    }
}