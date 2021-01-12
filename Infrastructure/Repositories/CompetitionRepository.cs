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
    public class CompetitionRepository : ICompetition
    {
        private ApplicationDbContext context;
        public CompetitionRepository()
        {
            context = new ApplicationDbContext();
        }

        public bool Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Competition> GetAll()
        {
            throw new NotImplementedException();
        }

        public Competition GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Competition GetCurrentCompetition()
        {
            return context.Competitions.First();
        }

        public bool Insert(Competition objT)
        {
            throw new NotImplementedException();
        }

        public bool Update(Competition objT)
        {
            throw new NotImplementedException();
        }
    }
}