using SurveyPortal.Infrastructure.Interface;
using SurveyPortal.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SurveyPortal.Infrastructure.Repositories
{
    public class FAQRepository : IFAQRepository
    {
        private ApplicationDbContext DB;

        public FAQRepository()
        {
            DB = ApplicationDbContext.Create();
        }

        public bool Delete(int Id)
        {
            FAQ fAQ = DB.FAQs
                .Where(f => f.Id == Id)
                .FirstOrDefault();
            DB.FAQs.Remove(fAQ);
            DB.SaveChanges();
            return true;
        }
        public List<FAQ> GetAll()
        {
            // method syntax
            // return DB.FAQs.ToList();

            // query syntax
            var query = from f in DB.FAQs
                        select f;
            return query.ToList();            
        }

        public FAQ GetById(int Id)
        {
            // method syntax;
            FAQ faq = DB.FAQs
                .Where(f => f.Id == Id)
                .FirstOrDefault();
            return faq;

            // query syntax
            //var query = from f in DB.FAQs
            //             where f.Id == Id
            //             select f;
            //return query.FirstOrDefault();
        }

        public bool Insert(FAQ objT)
        {
            DB.FAQs.Add(objT);
            DB.SaveChanges();
            return true;
        }

        public bool Update(FAQ objT)
        {

            var existing = DB.FAQs.Where(f => f.Id == objT.Id).FirstOrDefault();
            DB.Entry(existing).CurrentValues.SetValues(objT);
            DB.SaveChanges();
            return true;
            
        }
    }
}