using SurveyPortal.Infrastructure.Interface;
using SurveyPortal.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SurveyPortal.Infrastructure.Repositories
{
    public class CompetitionRepository : ICompetition
    {
        private ApplicationDbContext DB;

        public CompetitionRepository()
        {
            DB = ApplicationDbContext.Create();
        }

        public Competition GetCurrentCompetition()
        {
            var query = from c in DB.Competitions
                        join s in DB.Surveys on c.SurveyId equals s.Id
                        select new
                        {
                            c,
                            s
                        };

            var data = query.FirstOrDefault();
            Competition objCompetition = new Competition();
            objCompetition.Id = data.c.Id;
            objCompetition.Introduction = data.c.Introduction;
            objCompetition.Details = data.c.Details;
            objCompetition.StartDate = data.c.StartDate;
            objCompetition.EndDate = data.c.EndDate;
            objCompetition.RoleId = data.c.RoleId;
            objCompetition.SurveyId = data.c.SurveyId;
            objCompetition.SurveyName = data.s.Name;
            objCompetition.SurveyDescription = data.s.Description;

            return objCompetition;
        }
        public bool Delete(int Id)
        {
            Competition competition = DB.Competitions
                .Where(c => c.Id == Id)
                .FirstOrDefault();
            DB.Competitions.Remove(competition);
            DB.SaveChanges();
            return true;
        }

        public List<Competition> GetAll()
        {
            var query = from c in DB.Competitions
                        join s in DB.Surveys on c.SurveyId equals s.Id
                        select new { c, s };

            List<Competition> competition = new List<Competition>();
            foreach (var obj in query.ToList())
            {
                Competition objCompetition = new Competition();
                objCompetition.Id = obj.c.Id;
                objCompetition.Introduction = obj.c.Introduction;
                objCompetition.Details = obj.c.Details;
                objCompetition.SurveyId = obj.c.SurveyId;
                objCompetition.SurveyName = obj.s.Name;
                objCompetition.SurveyDescription = obj.s.Description;
                objCompetition.StartDate = obj.c.StartDate;
                objCompetition.EndDate = obj.c.EndDate;
                objCompetition.RoleId = obj.c.RoleId;
                competition.Add(objCompetition);
            }
            return competition;
        }

        public Competition GetById(int Id)
        {
            var query = from c in DB.Competitions
                        join s in DB.Surveys on c.SurveyId equals s.Id
                        where c.Id == Id
                        select new { c, s };

            var data = query.FirstOrDefault();
            Competition objCompetition = new Competition();
            objCompetition.Id = data.c.Id;
            objCompetition.Introduction = data.c.Introduction;
            objCompetition.Details = data.c.Details;
            objCompetition.StartDate = data.c.StartDate;
            objCompetition.EndDate = data.c.EndDate;
            objCompetition.RoleId = data.c.RoleId;
            objCompetition.SurveyId = data.s.Id;
            objCompetition.SurveyName = data.s.Name;
            objCompetition.SurveyDescription = data.s.Description;
            return objCompetition;
        }

        public bool Insert(Competition objT)
        {
            DB.Competitions.Add(objT);
            DB.SaveChanges();
            return true;
        }

        public bool Update(Competition objT)
        {
            var existing = DB.Competitions.Where(c => c.Id == objT.Id).First();
            DB.Entry(existing).CurrentValues.SetValues(objT);
            DB.SaveChanges();
            return true;
        }
    }
}