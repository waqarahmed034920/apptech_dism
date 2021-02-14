using SurveyPortal.Infrastructure.Interface;
using SurveyPortal.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SurveyPortal.Infrastructure.Repositories
{
    public class SurveyResponseRepository : ISurveyResponseRepository
    {
        private ApplicationDbContext DB;

        public SurveyResponseRepository()
        {
            DB = ApplicationDbContext.Create();
        }
        public bool Delete(int Id)
        {
            SurveyResponse surveyres = DB.SurveyResponses
                 .Where(c => c.Id == Id)
                 .FirstOrDefault();
            DB.SurveyResponses.Remove(surveyres);
            DB.SaveChanges();
            return true;
        }

        public List<SurveyResponse> GetAll()
        {
            var query = from sur in DB.SurveyResponses
                        select sur;
            List<SurveyResponse> SurveyRes = new List<SurveyResponse>();
            foreach (var obj in query.ToList())
            {
                SurveyResponse objsurRe = new SurveyResponse();
                objsurRe.Id = obj.Id;
                objsurRe.UserId = obj.UserId;
                objsurRe.ResponseDate = obj.ResponseDate;
                objsurRe.Response= obj.Response;
            }
            return SurveyRes;
        }

        public SurveyResponse GetById(int Id)
        {
            var query1 = from s in DB.SurveyResponses
                         where (s.Id == Id)
                         select s;
            return query1.FirstOrDefault();
        }

        public bool Insert(SurveyResponse objT)
        {
            DB.SurveyResponses.Add(objT);
            DB.SaveChanges();
            return true;
        }

        public bool Update(SurveyResponse objT)
        {

            var existing = DB.SurveyResponses.Where(s => s.Id == objT.Id).FirstOrDefault();
            DB.Entry(existing).CurrentValues.SetValues(objT);
            DB.SaveChanges();
            return true;
        }
    }
}
