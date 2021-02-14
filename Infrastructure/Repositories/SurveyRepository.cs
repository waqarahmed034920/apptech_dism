using SurveyPortal.Infrastructure.Interface;
using SurveyPortal.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SurveyPortal.Infrastructure.Repositories
{
    public class SurveyRepository : ISurveyRepository
    {
        private ApplicationDbContext DB;

        public SurveyRepository()
        {
            DB = ApplicationDbContext.Create();
        }
        public bool Delete(int Id)
        {
            Survey surveyss = DB.Surveys
               .Where(s => s.Id == Id)
               .FirstOrDefault();
            DB.Surveys.Remove(surveyss);
            DB.SaveChanges();
            return true;
        }

        public List<Survey> GetAll()
        {

            var query = from su in DB.Surveys
                        select su;
            List<Survey> Surveys = new List<Survey>();
            foreach (var obj in query.ToList())
            {
                Survey objsur = new Survey();
                objsur.Id = obj.Id;
                objsur.Name= obj.Name;
                objsur.StartDate= obj.StartDate;
                objsur.EndDate= obj.EndDate;
                objsur.BackButton= obj.BackButton;
                objsur.Reviewable= obj.Reviewable;
                objsur.InternalOnly = obj.InternalOnly;
                objsur.SurveyFor= obj.SurveyFor;
            }
            return Surveys;
        }

        public Survey GetById(int Id)
        {
            var query1 = from s in DB.Surveys
                         where (s.Id == Id)
                         select s;
            return query1.FirstOrDefault();
        }

        public bool Insert(Survey objT)
        {
            DB.Surveys.Add(objT);
            DB.SaveChanges();
            return true;
        }

        public bool Update(Survey objT)
        {
            var existing = DB.Surveys.Where(c => c.Id == objT.Id).First();
            DB.Entry(existing).CurrentValues.SetValues(objT);
            DB.SaveChanges();
            return true;
        }
    }
}
