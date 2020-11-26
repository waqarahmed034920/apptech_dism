using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyPortal.Infrastructure.Interface
{
    public interface IRepository<T> where T: class
    {
        bool Insert(T objT);
        bool Update(T objT);
        bool Delete(int Id);
        T GetById(int Id);
        List<T> GetAll();

    }
}
