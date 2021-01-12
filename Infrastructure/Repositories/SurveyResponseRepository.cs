using SurveyPortal.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SurveyPortal.Models;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace SurveyPortal.Infrastructure.Repositories
{
    public class SurveyResponseRepository : IRepository<SurveyResponse>
    {
        public bool Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public List<SurveyResponse> GetAll()
        {
            throw new NotImplementedException();
        }

        public SurveyResponse GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(SurveyResponse objT)
        {
            throw new NotImplementedException();
        }

        public bool Update(SurveyResponse objT)
        {
            throw new NotImplementedException();
        }
    }
}