using SurveyPortal.Infrastructure.Interface;
using SurveyPortal.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SurveyPortal.Infrastructure.Repositories
{
    public class OptionTypeRepository : IOptionTypeRepository
    {
        private ApplicationDbContext DB;

        public OptionTypeRepository()
        {
             DB = ApplicationDbContext.Create();
        }


        public bool Delete(int Id)
        {
            var option = DB.OptionTypes
            .Where(o => o.Id == Id)
            .FirstOrDefault();
            DB.OptionTypes.Remove(option);
            DB.SaveChanges();
            return true;
        }

        public List<OptionType> GetAll()
        {
            var query = from o in DB.OptionTypes
               select o;
            List<OptionType> OptionTypes = new List<OptionType>();
            foreach (var obj in query.ToList())
            {
                OptionType objopt = new OptionType();
                objopt.Id = obj.Id;
                objopt.Name = obj.Name;
                objopt.Description = obj.Description;
            }
            return query.ToList();
        }

        public OptionType GetById(int Id)
        {
            var query1 = from O in DB.OptionTypes
                         where (O.Id == Id)
                         select O;
            return query1.FirstOrDefault();
        }

        public bool Insert(OptionType objT)
        {
            DB.OptionTypes.Add(objT);
            DB.SaveChanges();
            return true;
        }

        public bool Update(OptionType objT)
        {
            var existing = DB.OptionTypes.Where(o => o.Id == objT.Id).FirstOrDefault();
            DB.Entry(existing).CurrentValues.SetValues(objT);
            DB.SaveChanges();
            return true;
        }
    }
}
