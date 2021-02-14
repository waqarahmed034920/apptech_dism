using SurveyPortal.Infrastructure.Interface;
using SurveyPortal.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SurveyPortal.Infrastructure.Repositories
{
    public class SupportInfoRepository : ISupportInfoRepository
    {
        private ApplicationDbContext DB;

        public SupportInfoRepository()
        {
            DB = ApplicationDbContext.Create();
        }
        public bool Delete(int Id)
        {
            var supports = DB.SupportInfoes
                .Where(s => s.Id == Id)
                .FirstOrDefault();
            DB.SupportInfoes.Remove(supports);
            DB.SaveChanges();
            return true;

        }

        public List<SupportInfo> GetAll()
        {
            var query = from s in DB.SupportInfoes
                        select s;
            List<SupportInfo> supportt = new List<SupportInfo>();
            foreach (var obj in query.ToList())
            {
                SupportInfo objsup = new SupportInfo();
                objsup.Id = obj.Id;
                objsup.Contact = obj.Contact;
                objsup.ShortDesc = obj.ShortDesc;
                objsup.Description = obj.Description;
                objsup.Email = obj.Email;
                objsup.Phone = obj.Phone;
                objsup.WhatsApp = obj.WhatsApp;
                objsup.SkypeId = obj.SkypeId;
                objsup.WebAddress = obj.WebAddress;
            }
            return query.ToList();
        }

        public SupportInfo GetById(int Id)
        {
            var query1 = from su in DB.SupportInfoes
                         where (su.Id == Id)
                         select su;
            return query1.FirstOrDefault();
        }

        public bool Insert(SupportInfo objT)
        {
            DB.SupportInfoes.Add(objT);
            DB.SaveChanges();
            return true;
        }

        public bool Update(SupportInfo objT)
        {
            var existing = DB.SupportInfoes.Where(o => o.Id == objT.Id).FirstOrDefault();
            DB.Entry(existing).CurrentValues.SetValues(objT);
            DB.SaveChanges();
            return true;
        }
    }
}