using SurveyPortal.Infrastructure.Interface;
using SurveyPortal.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SurveyPortal.Infrastructure.Repositories
{
    public class SurveyRepository : IRepository<Survey>
    {
        ApplicationDbContext context;

        public SurveyRepository()
        {
            this.context = new ApplicationDbContext();
        }

        public bool Delete(int Id)
        {
            context.Surveys.Remove(context.Surveys.Find(Id));
            return true;
        }

        public List<Survey> GetAll()
        {
            var query = from s in context.Surveys
                        select s;

            return query.ToList();
        }

        public Survey GetById(int Id)
        {
            var query = from s in context.Surveys
                        join q in context.SurveyQuestions on s.Id equals q.SurveyId
                        join o in context.Options on q.Id equals o.QuestionId
                        where s.Id == Id
                        select s;
            return query.First();
        }

        public bool Insert(Survey objT)
        {
            context.Surveys.Add(objT);
            context.SaveChanges();
            return true;
        }

        public bool Update(Survey objT)
        {
            Survey survey = context.Surveys.Where(s => s.Id == objT.Id).First();
            context.Entry(survey).CurrentValues.SetValues(survey);
            context.SaveChanges();
            return true;
        }
    }
}